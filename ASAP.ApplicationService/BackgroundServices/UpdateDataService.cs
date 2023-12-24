using ASAP.Domain.Data;
using ASAP.Domain.Entities;
using ASAP.Domain.Integration;
using ASAP.Domain.ISpecification.Client;
using ASAP.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace ASAP.ApplicationService.BackgroundServices;

public class UpdateDataService : BackgroundService
{
    private readonly ILogger<UpdateDataService> _logger;
    private readonly IServiceProvider serviceProvider;
 


    public UpdateDataService(ILogger<UpdateDataService> logger,
            IServiceProvider serviceProvider
        ) 
    {
        _logger = logger;
        this.serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service Started.");
     
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service Stopped.");
        return Task.CompletedTask;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker Running at: {time} ", DateTime.Now);
            await UpdateData(stoppingToken);
            await SendUpdatesEmailToClients(stoppingToken);
            await Task.Delay(6 * 60 * 1000, stoppingToken);
        }
    }

    public async Task UpdateData(CancellationToken stoppingToken) 
    {
        using var workerscope = serviceProvider.CreateScope();
        var polygonadapter = workerscope.ServiceProvider.GetRequiredService<IPolygonAdapter>();
        var genericRepository = workerscope.ServiceProvider.GetRequiredService<IGenericRepository<PolygonResponse, Guid>>();
        var ASAPUnitOfWork = workerscope.ServiceProvider.GetRequiredService<IASAPUnitOfWork>();
        var Response = await polygonadapter.GetUpdatedProductsInfo();
        var MappedResponse = PolygonResponse.Create(Response);
        MappedResponse.AddResults(Response.Results);
        await genericRepository.AddAsync(MappedResponse);
        await ASAPUnitOfWork.SaveAsync(stoppingToken);

    }

    public async Task SendUpdatesEmailToClients(CancellationToken stoppingToken)
    {
        using var workerscope = serviceProvider.CreateScope();
        var emailservices = workerscope.ServiceProvider.GetRequiredService<IEmailService>();
        var getclientsspecification = workerscope.ServiceProvider.GetRequiredService<IGetClientsSpecification>();
        var clients = await getclientsspecification.Query(stoppingToken);
        var emails = clients.Select(x => x.Email).ToList();
        emailservices.SendMails(emails);
    }

}

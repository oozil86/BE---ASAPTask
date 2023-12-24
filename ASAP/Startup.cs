using ASAP.ApplicationService.BackgroundServices;
using ASAP.Domain.Entities;
using ASAP.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scrutor;
using System.Text;

namespace ASAP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ASAPContext>(options =>
        options.UseSqlServer(
            Configuration?.GetConnectionString("ASAPDbConnectionString")));


            services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ASAPContext>();
           
            
            ConfigureCors(services);
            ConfigureDI(services);
            JWTConfigure(services);
            RunBackgroundServices(services);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(ApplicationService.AssemblyReference.Assembly));
            services.AddAutoMapper(ApplicationService.AssemblyReference.Assembly);
            services.AddValidatorsFromAssembly(ApplicationService.AssemblyReference.Assembly);
            services.AddFluentValidationAutoValidation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


           
            app.UseRouting();
            app.UseCors("TaskCors");
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected virtual void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(opt => {
                opt.AddPolicy("TaskCors", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
        }

        protected virtual void ConfigureDI(IServiceCollection services)
        {

            services.Scan(selector => selector
           .FromAssemblies(
               typeof(Domain.AssemblyReference).Assembly,
               typeof(AssemblyReference).Assembly)
           .AddClasses(publicOnly: false)
           .UsingRegistrationStrategy(RegistrationStrategy.Skip)
           .AsMatchingInterface()
           .WithScopedLifetime());
        }

        private void JWTConfigure(IServiceCollection services)
        {
            services.AddAuthentication(cgf =>
            {
                cgf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cgf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"])),
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false
                };
            });
        }

        private void RunBackgroundServices(IServiceCollection services)
        {
            services.AddHostedService<UpdateDataService>();
        }
    }
}

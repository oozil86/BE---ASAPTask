using ASAP.Domain.Model.Integration;
using System.Runtime.InteropServices;

namespace ASAP.Domain.Entities;

public class PolygonResponse : Entity<long>
{
    public string Ticker { private set; get; }
    public int QueryCount { private set; get; }
    public int ResultsCount { private set; get; }
    public bool Adjusted { private set; get; }
    public string Status { private set; get; }
    public string Request_Id { private set; get; }
    public int Count { private set; get; }
    private List<PolygonResponseResult> polygonResponseResults = new();
    public virtual IReadOnlyCollection<PolygonResponseResult> Results => polygonResponseResults.AsReadOnly();


    public static PolygonResponse Create(PolygonResponseModel PolygonResponse)
        => new()
        {
            Adjusted = PolygonResponse.Adjusted,
            Count = PolygonResponse.Count,
            QueryCount = PolygonResponse.QueryCount,
            Request_Id = PolygonResponse.Request_Id,
            ResultsCount = PolygonResponse.ResultsCount,
            Ticker = PolygonResponse.Ticker,
            Status = PolygonResponse.Status,
        };
    

    public void AddResults(List<PolygonResponseResultModel> results) 
    {
        foreach (var result in results)
        {
            var responnseresult = PolygonResponseResult.Create(result);
            polygonResponseResults.Add(responnseresult);
        }
    }
}

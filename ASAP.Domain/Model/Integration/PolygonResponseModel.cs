namespace ASAP.Domain.Model.Integration;

public class PolygonResponseModel
{
    public string Ticker { set; get; }
    public int QueryCount { set; get; }
    public int ResultsCount { set; get; }
    public bool Adjusted { set; get; }
    public List<PolygonResponseResultModel> Results { set; get; }
    public string Status { set; get; }
    public string Request_Id { set; get; }
    public int Count { set; get; }
}

public class PolygonResponseResultModel
{
    public double V { set; get; }
    public double VM { set; get; }
    public double O { set; get; }
    public double C { set; get; }
    public double H { set; get; }
    public double L { set; get; }
    public double T { set; get; }
    public double N { set; get; }
}

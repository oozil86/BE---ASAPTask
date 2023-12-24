using ASAP.Domain.Model.Integration;

namespace ASAP.Domain.Entities;

public class PolygonResponseResult : Entity<long>
{
    public double V { private set; get; }
    public double VM { private set; get; }
    public double O { private set; get; }
    public double C { private set; get; }
    public double H { private set; get; }
    public double L { private set; get; }
    public double T { private set; get; }
    public double N { private set; get; }
    public long PolygonResponseId { private set; get; } 
    public virtual PolygonResponse PolygonResponse { private set; get; }
    public static PolygonResponseResult Create(PolygonResponseResultModel PolygonResponseResult)
        => new()
        {
            C = PolygonResponseResult.C,
            H = PolygonResponseResult.H,
            L = PolygonResponseResult.L,
            N = PolygonResponseResult.N,
            O = PolygonResponseResult.O,
            T = PolygonResponseResult.T,
            V = PolygonResponseResult.V,
            VM = PolygonResponseResult.VM,
        };
    
}

namespace ASAP.Domain.Contracts;

public class PagationFilter
{
    public int PageIndex { set; get; }
    public int PageSize { set; get; }
    public int SortOrder { set; get; }
    public string SortField { set; get; }
}

using ASAP.Domain.Integration;
using ASAP.Domain.Model.Integration;
using Newtonsoft.Json;

namespace ASAP.Infrastructure.Integration
{
    public class PolygonAdapter : IPolygonAdapter
    {
        public async Task<PolygonResponseModel> GetUpdatedProductsInfo() 
        {
            PolygonResponseModel reponse = null;
            string apiUrl = "https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2023-01-09/2023-01-09?apiKey=0sXU6Ghh3uCzOKJRRX2179mui4IcwWp5"; // Replace with the API endpoint URL

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PolygonResponseModel>(apiResponse);
                }
                catch (HttpRequestException e)
                {
                }
            }
            return reponse;
        }
    }
}

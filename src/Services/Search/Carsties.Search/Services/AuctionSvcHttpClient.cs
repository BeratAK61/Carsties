using Carsties.Search.Models;
using MongoDB.Entities;

namespace Carsties.Search.Services;

public class AuctionSvcHttpClient
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public AuctionSvcHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<Item>> GetItemsForSearchDb()
    {
        var lastUpdated = await DB.Find<Item, string>()
            .Sort(x => x.Descending(x => x.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();

        return await _httpClient.GetFromJsonAsync<List<Item>>(_configuration["AuctionServiceUrl"] + "/api/auctions?date=" + lastUpdated);
    }
}

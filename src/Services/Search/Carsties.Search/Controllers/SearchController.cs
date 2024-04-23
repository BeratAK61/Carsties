﻿using Carsties.Search.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;

namespace Carsties.Search.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Item>>> SearchItems(string searchTerm)
    {
        var query = DB.Find<Item>();

        query.Sort(x => x.Ascending(a => a.Make));
        
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query.Match(MongoDB.Entities.Search.Full, searchTerm).SortByTextScore();
        }

        var result = await query.ExecuteAsync();

        return result;
    }
}

using Microsoft.AspNetCore.Mvc;
using GroceriesApi.Models;
using GroceriesApi.Repositories;
using GroceriesApi.Repositories.Context;

namespace GroceriesApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class GroceriesController : ControllerBase
{
    private readonly IGroceriesRepository _repository;

    private readonly DatabaseContext _context;

    public GroceriesController(DatabaseContext context, IGroceriesRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var items = await _repository.GetItemsAsync();

        return new OkObjectResult(items);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Item item)
    {
        _repository.UpdateItem(item);

        await _context.SaveChangesAsync();

        return new OkResult();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Item item)
    {
        _repository.AddItem(item);

        await _context.SaveChangesAsync();

        return new OkResult();
    }
}

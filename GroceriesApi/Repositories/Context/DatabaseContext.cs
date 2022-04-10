using Microsoft.EntityFrameworkCore;
using GroceriesApi.Models;

namespace GroceriesApi.Repositories.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
}
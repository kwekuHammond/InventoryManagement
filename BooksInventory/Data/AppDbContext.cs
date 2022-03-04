using BooksInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksInventory.Data;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//Constructor (gets executed when a class object is created)
    {
        //initialization codes

    }

    public DbSet<BookType> BookTypes { get; set; }
}
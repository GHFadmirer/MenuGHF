using MenuGHF.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuGHF.Data;

public class MenuContext : DbContext
{
    public MenuContext(DbContextOptions<MenuContext> options)
        : base(options)
    {
    }

    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
}

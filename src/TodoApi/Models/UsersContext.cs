using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
  
}
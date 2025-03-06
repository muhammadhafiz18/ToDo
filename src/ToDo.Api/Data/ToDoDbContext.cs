using Microsoft.EntityFrameworkCore;
using ToDo.Api.Entities;
using ToDo.Api.Entities.Configurations;

namespace ToDo.Api.Data;
public class ToDoDbContext(DbContextOptions<ToDoDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
    }
}
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.Entities;

namespace ToDo.Api.Repositories;

public class UserRepository(ToDoDbContext context) : IUserRepository
{
    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken) => 
        await context.Users.FirstOrDefaultAsync(u => u.Username == username, cancellationToken: cancellationToken);

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
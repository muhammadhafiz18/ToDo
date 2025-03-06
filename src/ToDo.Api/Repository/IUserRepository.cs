// Domain/Repositories/IUserRepository.cs
using ToDo.Api.Entities;

namespace ToDo.Api.Repository;
public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task AddAsync(User user, CancellationToken cancellationToken = default);
}
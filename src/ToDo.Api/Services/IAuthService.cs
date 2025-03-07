using ToDo.Api.Entities;

namespace ToDo.Api.Services;
public interface IAuthService
{
    Task<User> RegisterAsync(string username, string password);
    Task<string> LoginAsync(string username, string password);
}
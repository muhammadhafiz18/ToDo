using ToDo.Api.Dtos;
using ToDo.Api.Entities;

namespace ToDo.Api.Services;

public interface ITodoService
{
    Task<Todo> CreateTodoAsync(Guid userId, TodoDto todoDto);
    Task<IEnumerable<Todo>> GetAllTodosAsync(Guid userId);
    Task<Todo?> GetTodoByIdAsync(Guid userId, int todoId);
    Task UpdateTodoAsync(Guid userId, int todoId, TodoDto todoDto);
    Task DeleteTodoAsync(Guid userId, int todoId);
}

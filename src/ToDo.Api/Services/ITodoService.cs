using ToDo.Api.Dtos;
using ToDo.Api.Entities;

namespace ToDo.Api.Services;

public interface ITodoService
{
    Task<Todo> CreateTodoAsync(Guid userId, TodoDto todoDto);
    Task<IEnumerable<Todo>> GetAllTodosAsync(Guid userId);
    Task<Todo?> GetTodoByIdAsync(Guid userId, Guid todoId);
    Task UpdateTodoAsync(Guid userId, Guid todoId, TodoDto todoDto);
    Task DeleteTodoAsync(Guid userId, Guid todoId);
}

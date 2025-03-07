using ToDo.Api.Entities;

namespace ToDo.Api.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> CreateTodoAsync(Todo todo);
        Task<IEnumerable<Todo>> GetAllTodosAsync(Guid userId);
        Task<Todo?> GetTodoByIdAsync(Guid userId, Guid todoId);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(Todo todo);
    }
}
using ToDo.Api.Dtos;
using ToDo.Api.Entities;
using ToDo.Api.Repositories;

namespace ToDo.Api.Services;

public class TodoService(ITodoRepository todoRepository) : ITodoService
{
    public async Task<Todo> CreateTodoAsync(Guid userId, TodoDto todoDto)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid(),
            Title = todoDto.Title,
            Description = todoDto.Description,
            IsCompleted = todoDto.IsCompleted,
            UserId = userId
        };

        return await todoRepository.CreateTodoAsync(todo);
    }

    public async Task<IEnumerable<Todo>> GetAllTodosAsync(Guid userId)
        => await todoRepository.GetAllTodosAsync(userId);

    public async Task<Todo?> GetTodoByIdAsync(Guid userId, Guid todoId)
        => await todoRepository.GetTodoByIdAsync(userId, todoId);

    public async Task UpdateTodoAsync(Guid userId, Guid todoId, TodoDto todoDto)
    {
        var todo = await todoRepository.GetTodoByIdAsync(userId, todoId) 
            ?? throw new KeyNotFoundException("Todo not found.");

        todo.Title = todoDto.Title;
        todo.Description = todoDto.Description;
        todo.IsCompleted = todoDto.IsCompleted;

        await todoRepository.UpdateTodoAsync(todo);
    }

    public async Task DeleteTodoAsync(Guid userId, Guid todoId)
    {
        var todo = await todoRepository.GetTodoByIdAsync(userId, todoId) 
            ?? throw new KeyNotFoundException("Todo not found.");
            
        await todoRepository.DeleteTodoAsync(todo);
    }
}
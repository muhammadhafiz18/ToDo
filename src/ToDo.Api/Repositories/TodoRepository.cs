using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.Entities;

namespace ToDo.Api.Repositories
{
    public class TodoRepository(ToDoDbContext context) : ITodoRepository
    {
        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            context.Todos.Add(todo);
            await context.SaveChangesAsync();
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync(Guid userId)
        {
            return await context.Todos
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<Todo?> GetTodoByIdAsync(Guid userId, int todoId)
        {
            return await context.Todos
                .FirstOrDefaultAsync(t => t.UserId == userId && t.Id == todoId);
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            context.Todos.Update(todo);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(Todo todo)
        {
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();
        }
    }
}
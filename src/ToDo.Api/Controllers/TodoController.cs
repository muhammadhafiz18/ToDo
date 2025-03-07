using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Dtos;
using ToDo.Api.Entities;
using ToDo.Api.Services;

namespace ToDo.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/todos")]
public class TodoController(
    ITodoService todoService,
    IValidator<TodoDto> todoValidator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTodo(TodoDto request)
    {
        var validationResult = await todoValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var userId = GetUserId();
        var todo = await todoService.CreateTodoAsync(userId, request);
        return Created($"api/todos/{todo.Id}", todo);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTodos()
    {
        var userId = GetUserId();
        var todos = await todoService.GetAllTodosAsync(userId);
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        var userId = GetUserId();
        var todo = await todoService.GetTodoByIdAsync(userId, id);
        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, TodoDto request)
    {
        var validationResult = await todoValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var userId = GetUserId();
        await todoService.UpdateTodoAsync(userId, id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var userId = GetUserId();
        await todoService.DeleteTodoAsync(userId, id);
        return NoContent();
    }

    private Guid GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim is null || !Guid.TryParse(userIdClaim, out var userId))
            throw new UnauthorizedAccessException("Invalid user ID");

        return userId;
    }

}
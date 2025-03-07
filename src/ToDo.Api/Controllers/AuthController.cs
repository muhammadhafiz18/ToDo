using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Dtos;
using ToDo.Api.Services;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService, 
    IValidator<RegisterRequest> registerValidator, 
    IValidator<LoginRequest> loginValidator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var validationResult = await registerValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        _ = await authService.RegisterAsync(request.Username!, request.Password!);
        return Created(uri: $"api/register/{request.Username}", value: request);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var validationResult = await loginValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var token = await authService.LoginAsync(request.Username!, request.Password!);
        return Ok(new { Token = token });
    }
}
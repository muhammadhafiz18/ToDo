namespace ToDo.Api.Entities;
public class User
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public List<Todo> Todos { get; set; } = [];
}
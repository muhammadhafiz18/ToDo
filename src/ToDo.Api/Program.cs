using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Todo")));

var app = builder.Build();

app.Run();
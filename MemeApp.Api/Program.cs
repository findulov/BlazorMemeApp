using MediatR;
using MemeApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<MemeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MemesDb")));

builder.Services.AddMediatR(Assembly.Load("MemeApp.Infrastructure"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(corsOptions =>
{
    corsOptions.AllowAnyHeader();
    corsOptions.AllowAnyMethod();
    corsOptions.AllowAnyOrigin();
});

app.MapControllers();

app.Run();

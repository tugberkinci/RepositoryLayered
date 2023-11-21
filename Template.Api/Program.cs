using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Template.Data;
using Template.Data.Services.Abstract;
using Template.Data.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MsSqlConnection");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

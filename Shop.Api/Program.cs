using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Repositories;
using Shop.Core.Stores;
using Shop.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserStore, UserRepository>();
builder.Services.AddScoped<ILoginCodeStore, LoginCodeRepository>();

builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

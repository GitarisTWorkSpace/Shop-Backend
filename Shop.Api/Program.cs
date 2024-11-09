using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Extensions;
using Shop.Data;
using Shop.Infrastructure.Email;
using Shop.Infrastructure.JWT;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.RegisterServices();

builder.Services.RegisterRepositories();

builder.Services.RegisterInfrastructures();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection(nameof(EmailOptions)));

builder.Services.AddApiAuthentication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions 
{ 
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();

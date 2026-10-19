using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Unterrichtsorganisation.Models;
using Unterrichtsorganisation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<UnterrichtsorganisationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FormService>();
builder.Services.AddScoped<DepartmentManagerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}
app.MapScalarApiReference(options => {
    options.DisableMcp();
    options.DisableAgent();
    options.HideClientButton();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

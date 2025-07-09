using HeladeriaAPI.Config;
using HeladeriaAPI.Data;
using HeladeriaAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Services
builder.Services.AddScoped<HeladoServices>();
builder.Services.AddScoped<EnvaseServices>();

// Mapper
builder.Services.AddAutoMapper(typeof(Mapping));


builder.Services.AddDbContext<HeladeriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

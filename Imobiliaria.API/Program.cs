using Imobiliaria.Application.Interfaces;
using Imobiliaria.Application.Services;
using Imobiliaria.Domain.Interfaces;
using Imobiliaria.Infrastructure.Context;
using Imobiliaria.Infrastructure.Repositories;
using Imobiliaria.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<IImovelService, ImovelService>();
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddHttpClient<IViaCepService, ViaCepService>();

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

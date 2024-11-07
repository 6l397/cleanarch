using System.Reflection;
using application.AutoMapper;
using application.Reviews.Commands.Create;
using domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(CreateReviewHandler).Assembly));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<DogmateMarketplaceContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("reviewservice")));

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

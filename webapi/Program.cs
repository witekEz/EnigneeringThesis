using Microsoft.EntityFrameworkCore;
using UA.DAL.EF;
using UA.Services;
using UA.Services.Interfaces;
using UA.Services.Mapper;
using UA.Services.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Connection to database
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options=>
    options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Seed data
builder.Services.AddScoped<GenerationSeeder>();
//AutoMapper
builder.Services.AddAutoMapper(typeof(GenerationMappingProfile));
builder.Services.AddScoped<IGenerationService,GenerationService>();
var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<GenerationSeeder>(); 
seeder.Seed();
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

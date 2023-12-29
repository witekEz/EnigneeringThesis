using Microsoft.EntityFrameworkCore;
using UA.DAL.EF;
using UA.Services;
using UA.Services.Interfaces;
using UA.Services.Mapper;
using UA.Services.Seeders;
using NLog;
using NLog.Web;
using System;
using UA.Services.Middleware;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Project starting...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    //NLog Setup
    //builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container.

    builder.Services.AddControllers();
    //Connection to database
    var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //Seed data
    builder.Services.AddScoped<GenerationSeeder>();
    //AutoMapper
    builder.Services.AddAutoMapper(typeof(GenerationMappingProfile));
    builder.Services.AddScoped<IGenerationService, GenerationService>();
    builder.Services.AddScoped<IBrandService, BrandService>();
    builder.Services.AddScoped<IModelService, ModelService>();
    builder.Services.AddScoped<IHomeService, HomeService>();
    builder.Services.AddScoped<IBodyTypeService, BodyTypeService>();
    builder.Services.AddScoped<IDrivetrainService, DrivetrainService>();

    //Middleware
    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Services.AddScoped<RequestTimeMiddleware>();

    //Buildier
    var app = builder.Build();


    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<GenerationSeeder>();
    seeder.Seed();
    // Configure the HTTP request pipeline.

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}

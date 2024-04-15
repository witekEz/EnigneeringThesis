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
using Microsoft.AspNetCore.Identity;
using UA.Model.Entities.Authentication;
using FluentValidation;
using UA.Services.Validators;
using FluentValidation.AspNetCore;
using UA.WebAPI;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UA.Model.Queries;
using Microsoft.AspNetCore.Authorization;
using UA.Services.Authorization;
using UA.Model.DTOs.Read;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Project starting...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    //NLog Setup
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    //Authentication
    var authenticationSettings = new AuthenticationSettings();
    builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
    builder.Services.AddSingleton(authenticationSettings);
    builder.Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = "Bearer";
        option.DefaultScheme = "Bearer";
        option.DefaultChallengeScheme = "Bearer";
    }).AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = authenticationSettings.JwtIssuer,
            ValidAudience = authenticationSettings.JwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
        };
    });

    // Add services to the container.

    builder.Services.AddControllers();//.AddFluentValidation();
    builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
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
    builder.Services.AddScoped<IBodyService, BodyService>();
    builder.Services.AddScoped<IDrivetrainService, DrivetrainService>();
    builder.Services.AddScoped<IEngineService, EngineService>();
    builder.Services.AddScoped<IGearboxService, GearboxService>();
    builder.Services.AddScoped<IAccountService, AccountService>();
    builder.Services.AddScoped<IDetailedInfoService, DetailedInfoService>();
    builder.Services.AddScoped<ISuspensionService, SuspensionService>();
    builder.Services.AddScoped<IBrakeService, BrakeService>();
    builder.Services.AddScoped<IBodyColourService, BodyColourService>();
    builder.Services.AddScoped<IOptionalEquipmentService, OptionalEquipmentService>();
    builder.Services.AddScoped<IGenerationImageService, GenerationImageService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IBodyTypeService, BodyTypeService>();
    builder.Services.AddScoped<IRateGenerationService, RateGenerationService>();
    builder.Services.AddScoped<IRateEngineService, RateEngineService>();
    builder.Services.AddScoped<IRateGearboxService,RateGearboxService>();
    builder.Services.AddScoped<ICommentService, CommentService>();
    builder.Services.AddScoped<ICommentReplyService, CommentReplyService>();
    builder.Services.AddScoped<IUserService, UserService>();

    //Validator
    builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    builder.Services.AddScoped<IValidator<RegisterUserDTO>,RegisterUserDtoValidator>();
    builder.Services.AddScoped<IValidator<GenerationQuery>, GenerationQueryValidator>();

    //Middleware
    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Services.AddScoped<RequestTimeMiddleware>();

    //Authorization
    builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementRateGenerationHandler>();
    builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementCommentHandler>();
    builder.Services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementCommentReplyHandler>();

    //CORS
    var allowedOrigins = builder.Configuration["AllowedOrigins"];
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Client", builder =>
            builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("https://localhost:5173")
        );
    });
    
    //Buildier
    var app = builder.Build();

    app.UseCors("Client");
    app.UseStaticFiles();
    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<GenerationSeeder>();
    seeder.Seed();
    // Configure the HTTP request pipeline.
    
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeMiddleware>();
    app.UseAuthentication();

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

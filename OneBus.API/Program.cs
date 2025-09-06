using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OneBus.API.Converters;
using OneBus.API.Handlers;
using OneBus.Domain.Settings;
using OneBus.Infra.Data.DbContexts;
using OneBus.Infra.Ioc;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container:

builder.Services
    .AddControllers()
    .AddJsonOptions(c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddJsonOptions(c => c.JsonSerializerOptions.Converters.Add(new TrimmingJsonConverter()));

// Configuring json visualization for Enums 
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// appsettings configurations
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

var isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER")?.Equals("true") ?? false;

if (isDocker)
{
    builder.Configuration
        .AddJsonFile("appsettings.Docker.json", optional: true, reloadOnChange: true);
}

builder.Configuration.AddEnvironmentVariables();

// Add Options Pattern
builder.Services
    .AddOptions<TokenSettings>()
    .BindConfiguration("TokenSettings");

// Adds IoC configurations
builder.Services.AddInfrastructure();

// Add Swagger with JWT Bearer configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OneBus API",
        Version = "v1",
        Description = "OneBus API - Gestão de frotas para empresas de ônibus urbanos",
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://github.com/OneBus/OneBus-API?tab=MIT-1-ov-file#readme")
        },
        Contact = new OpenApiContact
        {
            Email = "iseduardo.rezende@gmail.com",
            Name = "OneBus API Owner",
            Url = new Uri("https://www.linkedin.com/in/eduardo-rezende-5218bb234/")
        },
        TermsOfService = new Uri("https://github.com/OneBus/OneBus-API?tab=MIT-1-ov-file#readme")
    });

    options.EnableAnnotations();
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "OneBus.API.xml"));

    options.SupportNonNullableReferenceTypes();
    options.UseAllOfToExtendReferenceSchemas();

    // Apply default value into Enums
    options.UseInlineDefinitionsForEnums();

    // Add JWT Bearer configuration to Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// Authentication settings
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TokenSettings:Issuer"],
        ValidAudience = builder.Configuration["TokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["TokenSettings:Key"]!))
    };
});

// Exception Handler configurations
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add DbContext Service
builder.Services.AddDbContext<OneBusDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"),
        sqlServerOpts =>
        {
            sqlServerOpts.MigrationsAssembly(typeof(OneBusDbContext).Assembly);
            sqlServerOpts.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), null);
        }
    );
});

// Add Rate Limiter configurations
builder.Services.AddRateLimiter();

builder.Services.AddCors(options => options.AddPolicy("*", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

// Just use ExceptionHandler in PRODUCTION Environment
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

// Adds automatic Migration when running application
using (IServiceScope scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OneBusDbContext>();
    dbContext.Database.Migrate();
}

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.EnableDeepLinking();
    options.RoutePrefix = "swagger";
    options.DisplayRequestDuration();
    options.EnablePersistAuthorization();
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "OneBus API v1");
});

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseCors("*");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

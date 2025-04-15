using System.Text;
using OneBus.Infra.Ioc;
using OneBus.API.Handlers;
using Microsoft.OpenApi.Models;
using OneBus.Infra.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OneBus.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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

builder.Services
    .AddOptions<EmailSettings>()
    .BindConfiguration("EmailSettings");

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
        //TermsOfService = new Uri("..."),
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
        ValidIssuer = builder.Configuration["TokenConfigurations:Issuer"],
        ValidAudience = builder.Configuration["TokenConfigurations:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["TokenConfigurations:Key"]!))
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"),
        sqlServerOpts =>
        {
            sqlServerOpts.MigrationsAssembly(typeof(OneBusDbContext).Assembly);
            sqlServerOpts.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), null);
        }
    );
});

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

app.UseHttpsRedirection();

app.UseCors("*");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

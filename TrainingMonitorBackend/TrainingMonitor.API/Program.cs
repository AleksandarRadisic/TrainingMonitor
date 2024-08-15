using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using TrainingMonitor.API.Swagger;
using TrainingMonitor.API.Utilities.Implementation;
using TrainingMonitor.API.Utilities.Interface;
using TrainingMonitor.Domain.PersistenceInterfaces;
using TrainingMonitor.Domain.Services.Implementation;
using TrainingMonitor.Domain.Services.Interface;
using TrainingMonitor.Domain.Utilities.Implementation;
using TrainingMonitor.Domain.Utilities.Interface;
using TrainingMonitor.Persistence.EfStructures;
using TrainingMonitor.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAnyOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(SwaggerOptionsConfig.Configure);

builder.Services.AddAuthentication(cfg =>
{
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = false,
    };
});

using (var context = new AppDbContextFactory().CreateDbContext(new[] { builder.Configuration.GetConnectionString("connectionString") }))
{
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("connectionString"));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtUtility, JwtUtility>();
builder.Services.AddScoped<IEncryptionUtility, EncryptionUtility>();
builder.Services.AddScoped<IUserReadRepository, UserReadRepository>();
builder.Services.AddScoped<IUserWriteRepository, UserWriteRepository>();
builder.Services.AddScoped<ITrainingWriteRepository, TrainingWriteRepository>();
builder.Services.AddScoped<ITrainingReadRepository, TrainingReadRepository>();
builder.Services.AddScoped<IExceptionHandler, ExceptionHandler>();
builder.Services.AddScoped<IHttpContextExtractor, HttpContextExtractor>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainingMonitor v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAnyOrigin");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

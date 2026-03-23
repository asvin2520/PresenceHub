using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presencehub.Application.Mapper;
using Presencehub.Application.ServiceClass;
using Presencehub.Application.ServiceInterface;
using Presencehub.Domain.RepoInterface;
using Presencehub.Infrastructure.Dbcontextclass;
using Presencehub.Infrastructure.RepositoryClass;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Register DbContext (MUST be before builder.Build())
builder.Services.AddDbContext<PresencehubDbContextClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repository
builder.Services.AddScoped<IRolesRepoInterface, RolesRepoClass>();
builder.Services.AddScoped<IUserRepoInterface, UserRepoClass>();
builder.Services.AddScoped<IAttendenceRepoInterface, AttendencesRepoClass>();

// Service
builder.Services.AddScoped<IRoleServicesInterface, RoleServicesClass>();
builder.Services.AddScoped<IUserServicesInterface, UserServicesClass>();
builder.Services.AddScoped<TokenServices>();
builder.Services.AddScoped<IAttendenceServicesInterface, AttendencesServicesClass>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(PresencehubProfile));


builder.Logging.ClearProviders();

builder.Logging.AddLog4Net("log4net.config"); // Path to config file


// 🔹 Read JWT settings
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
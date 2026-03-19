using Microsoft.EntityFrameworkCore;
using Presencehub.Application.Mapper;
using Presencehub.Application.ServiceClass;
using Presencehub.Application.ServiceInterface;
using Presencehub.Domain.RepoInterface;
using Presencehub.Infrastructure.Dbcontextclass;
using Presencehub.Infrastructure.RepositoryClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Register DbContext (MUST be before builder.Build())
builder.Services.AddDbContext<PresencehubDbContextClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repository
builder.Services.AddScoped<IRolesRepoInterface, RolesRepoClass>();

// Service
builder.Services.AddScoped<IRoleServicesInterface, RoleServicesClass>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(PresencehubProfile));

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
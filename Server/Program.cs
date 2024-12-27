using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using ServerLibrary.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "EMS Server",
        Version = "v1.0",
        // Description = "This is an Employee Management API",
        // Contact = new OpenApiContact
        // {
        //     Name = "Sagar Adhikari",
        //     Email = "sagradhkr48@gmail.com",
        //     Url = new Uri("https://www.sagaradhikari.info.np/")
        // }
    });
});

//starting
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
                         throw new InvalidOperationException("Connection string not found"));
});

builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));
builder.Services.AddScoped<IUserAccount, UserAccountRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        builder => builder.WithOrigins("https://localhost:7026", "http://localhost:5026").AllowAnyMethod()
            .AllowAnyHeader().AllowCredentials());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorWasm");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
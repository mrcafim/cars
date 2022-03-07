using Cars.Infra.Data;
using Cars.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependencyInjector.Register(builder.Services);
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "Cars"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Cars API",
        Description = "Cars API Swagger surface",
        Contact = new OpenApiContact
        {
            Name = "Matheus Alves",
            Email = "carvalho.matheus1997@gmail.com",
            Url = new Uri("https://github.com/mrcafim")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

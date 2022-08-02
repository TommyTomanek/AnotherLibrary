global using Library.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssemblyContaining<Program>();

        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

//builder.Services.AddControllers()
//    .AddFluentValidation(c =>
//    c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});




//builder.Services.AddValidatorsFromAssemblyContaining<ValidationEmploye>();
//builder.Services.AddValidatorsFromAssemblyContaining<ValidationBook>();
//builder.Services.AddValidatorsFromAssemblyContaining<ValidationPerson>();
//builder.Services.AddValidatorsFromAssemblyContaining<ValidationCustomer>();

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

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

using Microsoft.Data.SqlClient;
using Repository;
using SQLrepository;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
//builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
// Add other services as needed

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

string connectionString = configuration.GetConnectionString("SqlConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    var connection = new SqlConnection(connectionString);
    return connection;
});



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

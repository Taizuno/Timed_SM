using AskTrevor.Data;
using Microsoft.EntityFrameworkCore;
using AskTrevor.Service.Comment;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// static IHostBuilder CreateHostBuilder(string[] args) =>
//         Host.CreateDefaultBuilder(args)
// .ConfigureWebHostDefaults(webBuilder =>{
//     webBuilder.UseUrls("http://localhost:5075", "https://localhost:7160");
// });

// builder.Services.AddHttpsRedirection(options => options.HttpsPort = 7160);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Comment Service Dependency Injection
builder.Services.AddScoped<ICommentService, CommentService>();


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

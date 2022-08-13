using AskTrevor.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AskTrevor.Service.Post;
using AskTrevor.Service.Comment;
using Microsoft.OpenApi.Models;
using AskTrevor.Service.Reply;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();


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

<<<<<<< HEAD
// Comment Service Dependency Injection
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IReplyService, ReplyService>();

=======
>>>>>>> 65a5c4c85f0e53810f6f2e744b972f32be76ba1a

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using AskTrevor.Data.Entities;

namespace AskTrevor.Data
{
    public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }   
    
    public DbSet<CommentEntity> Comment { get; set; }
    
    public DbSet<PostEntity> Posts { get; set; } 

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AskTrevor.Data
{
    public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }   
    
    public DbSet<PostEntity> Posts { get; set; } 
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<ReplyEntity> Replies { get; set; }

    }
}
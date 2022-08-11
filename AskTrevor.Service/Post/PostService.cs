using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Data;
using AskTrevor.Data.Entities;
using AskTrevor.Models.Post;
using Microsoft.EntityFrameworkCore;

namespace AskTrevor.Service.Post
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;
        public PostService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreatePostAsync(PostCreate model)
        {
            if (await GetPostByUsernameAsync(model.Username) != null)
                return false;
                
            var entity = new PostEntity
            {
                Title = model.Title,
                Text = model.Text,
                Username = model.Username,
                PostCreatedAt = DateTime.Now
            };
            _context.Posts.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        private async Task<PostEntity> GetPostByUsernameAsync(string username)
        {
            return await _context.Posts.FirstOrDefaultAsync(post => post.Username.ToLower() == username.ToLower());
        }
    }
}
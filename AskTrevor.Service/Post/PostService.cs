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
            if (await GetUsernameAsync(model.Username) != null)
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
        
        public async Task<PostDetail> GetPostByIdAsync(int Id)
        {
            var entity = await _context.Posts.FindAsync(Id);
            if (entity is null)
            return null;

            var postDetail = new PostDetail
            {
                Id = entity.Id,
                Title = entity.Title,
                Text = entity.Text,
                Username = entity.Username,
                PostCreatedAt = entity.PostCreatedAt
            };
            return postDetail;
        }
        //GETPOSTSBYUSERNAME
        public async Task<PostDetail> GetPostByUsernameAsync(string Username)
        {
            var postEntity = await _context.Posts.FindAsync(Username);
            if (postEntity is null)
            return null;

            var usernameDetail = new PostDetail
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                Text = postEntity.Text,
                Username = postEntity.Username,
                PostCreatedAt = postEntity.PostCreatedAt
            };
            return usernameDetail;
        }
        public async Task<bool> DeletePostAsync(int Id)
        {
            var postEntity = await _context.Posts.FindAsync(Id);

            if (postEntity?.Id != Id)
                return false;

            _context.Posts.Remove(postEntity);
            return await _context.SaveChangesAsync() == 1;
        }
        private async Task<PostEntity> GetUsernameAsync(string username)
        {
            return await _context.Posts.FirstOrDefaultAsync(post => post.Username.ToLower() == username.ToLower());
        }
    }
}
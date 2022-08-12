using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Models.Post;

namespace AskTrevor.Service.Post
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(PostCreate model);
        Task<PostDetail> GetPostByIdAsync(int Id);
        Task<PostDetail> GetPostByUsernameAsync(string Username);
        Task<bool> DeletePostAsync(int Id);
        // Task<bool> UpdatePostAsync(PostUpdate request);
        // Task<bool> DeleteAPostAsync(int Id);
    }
}
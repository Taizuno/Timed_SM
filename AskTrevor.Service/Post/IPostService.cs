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
    }
}
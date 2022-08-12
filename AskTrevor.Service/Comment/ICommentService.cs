using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Data.Entities;
using AskTrevor.Models.Comment;

namespace AskTrevor.Service.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CommentCreate model);
        Task<CommentDetail> GetCommentByIdAsync(int commentId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Data;
using AskTrevor.Data.Entities;
using AskTrevor.Models.Comment;

namespace AskTrevor.Service.Comment
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        public CommentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCommentAsync(CommentCreate model)
        {
            var entity = new CommentEntity
            {
                Id = model.Id,
                Text = model.Text,
                Username = model.Username,
                CommentCreatedAt = DateTime.Now
            };

            _context.Comments.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<CommentDetail> GetCommentByIdAsync(int commentId)
        {
            var entity = await _context.Comments.FindAsync(commentId);
            if (entity is null)
                return null;
            
            var commentDetail = new CommentDetail
            {
                Id = entity.Id,
                Text = entity.Text,
                Username = entity.Username,
                CommentCreatedAt = entity.CommentCreatedAt
            };
            return commentDetail;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var commentEntity = await _context.Comments.FindAsync(commentId);

            if (commentEntity?.Id != commentId)
                return false;

            _context.Comments.Remove(commentEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
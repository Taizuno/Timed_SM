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
    }
}
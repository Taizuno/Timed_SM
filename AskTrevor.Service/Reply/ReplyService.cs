using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Data;
using AskTrevor.Models.Reply;

namespace AskTrevor.Service.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly AppDbContext _context;
        public ReplyService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateReplyAsync(ReplyCreate model)
        {
            var entity = new ReplyEntity
            {
                Text = model.Text,
                UserName = model.UserName,
                ReplyCreatedAt = DateTime.Now
            };
        _context.Replies.Add(entity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1; 
        }

        
    }
}
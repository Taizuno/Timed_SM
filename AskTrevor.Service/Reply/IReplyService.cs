using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskTrevor.Models.Reply;

namespace AskTrevor.Service.Reply
{
    public interface IReplyService
    {
        Task<bool> CreateReplyAsync(ReplyCreate model);
    }
}
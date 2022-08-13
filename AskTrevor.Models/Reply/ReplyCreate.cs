using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AskTrevor.Models.Reply
{
    public class ReplyCreate
    {
        
        [Required]
        public string Text {get; set;}
        [Required]
        public string UserName {get; set;}
        [Required]
        public DateTime CreatedAt {get; set;}
    }
}
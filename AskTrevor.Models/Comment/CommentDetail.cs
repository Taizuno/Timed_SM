using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AskTrevor.Models.Comment
{
    public class CommentDetail
    {
        public class CommentDetail
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public string Text { get; set; }
            [Required]
            [MinLength(4)]
            public string Username { get; set; }
            [Required]
            public DateTime CommentCreatedAt { get; set; }
        }
    }
}
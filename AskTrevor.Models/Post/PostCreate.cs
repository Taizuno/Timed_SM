using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AskTrevor.Models.Post
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Username { get; set; }
        public DateTime PostCreatedAt { get; set; }
    }
}
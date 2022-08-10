using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AskTrevor.Data.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime CommentCreatedAt { get; set; }
    }
}
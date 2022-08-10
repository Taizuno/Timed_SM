using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AskTrevor.Data.Entities
{
    public class PostEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public Datetime CreatedAt { get; set; }
    }
}
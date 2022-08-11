using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AskTrevor.Data
{
    public class Reply
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string Text {get; set;}
        [Required]
        public string UserName {get; set;}
        [Required]
        public DateTime Created {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskTrevor.Models.Post
{
    public class PostUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Domain.Aggregates.PostAggregate
{
    public sealed class Post :Entity<PostId>
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public bool IsNew { get; private set; }

        private Post(string title, string content,bool isNew, PostId? id = null):base(id?? PostId.CreateUnique())
        {
            Title = title;
            Content= content;
        }

        public static Post Create(string title,string content, PostId? id = null)
        {
            return new Post(title, content,true, id);
        }
        private Post()
        {
            
        }
    }
}

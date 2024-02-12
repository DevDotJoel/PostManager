using PostManager.Domain.Aggregates.CommentAggregate.ValueObjects;
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Domain.Aggregates.CommentAggregate
{
    public sealed class Comment:Entity<CommentId>
    {
        public PostId PostId { get; private set; }
        public string Content { get; private set; }
        public UserId UserId { get; private set; }
        private Comment(PostId postId,string content,UserId userId,CommentId? id=null):base(id?? CommentId.CreateUnique()) 
        {
            PostId = postId;
            Content = content;
            UserId = userId;
        
        }
        public static Comment Create(PostId postId, string content, UserId userId, CommentId? id = null)
        {
            return new Comment(postId, content,userId, id);
        }
        private Comment()
        {
            
        }

    }
}

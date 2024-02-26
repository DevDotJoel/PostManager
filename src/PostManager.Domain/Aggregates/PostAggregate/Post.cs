using PostManager.Domain.Aggregates.CommentAggregate.ValueObjects;
using PostManager.Domain.Aggregates.PostAggregate.ValueObjects;
using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Domain.Aggregates.PostAggregate
{
    public sealed class Post : Entity<PostId>
    {
        private List<CommentId> _commentIds = new();
        public string Title { get; private set; }
        public string Content { get; private set; }
        public bool IsNew { get; private set; }

        public UserId UserId { get; private set; }
        public IReadOnlyList<CommentId> CommentIds => _commentIds.AsReadOnly();
        private Post(string title, string content, bool isNew, UserId userId, PostId? id = null) : base(id ?? PostId.CreateUnique())
        {
            Title = title;
            Content = content;
            IsNew = isNew;
            UserId = userId;

        }

        public static Post Create(string title, string content, UserId userId, PostId? id = null)
        {
            return new Post(title, content, true, userId, id);
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
        public void SetContent(string content)
        {
            Content = content;
        }
        private Post()
        {

        }
    }
}

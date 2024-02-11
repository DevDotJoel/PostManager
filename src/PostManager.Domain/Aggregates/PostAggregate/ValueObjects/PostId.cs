using PostManager.Domain.Common.Models;
using PostManager.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Domain.Aggregates.PostAggregate.ValueObjects
{
    public class PostId : EntityId<Guid>
    {
        private PostId(Guid value):base(value)
        {
            
        }

        public static PostId Create(Guid value)
        {
            return new PostId(value);
        }
        public static PostId CreateUnique()
        {
            return new PostId(Guid.NewGuid());
        }
    }
}

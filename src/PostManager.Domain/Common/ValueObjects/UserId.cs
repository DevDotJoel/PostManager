﻿using PostManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Domain.Common.ValueObjects
{
    public sealed class UserId : EntityId<Guid>
    {
        private UserId(Guid value) : base(value) { }

        public static UserId Create(Guid value)
        {
            return new UserId(value);

        }
    }
}

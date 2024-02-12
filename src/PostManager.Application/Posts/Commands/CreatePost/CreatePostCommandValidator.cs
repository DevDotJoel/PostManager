using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator:AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Title).MinimumLength(5).MaximumLength(50);
            RuleFor(x => x.Content).MinimumLength(5).MaximumLength(10000);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Application.Queries
{
    public class GetTopicByIdQueryValidator : AbstractValidator<GetTopicByIdQuery>
    {
        public GetTopicByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .LessThan(0)
                .WithMessage("Id is less than 0.");
        }
    }
}

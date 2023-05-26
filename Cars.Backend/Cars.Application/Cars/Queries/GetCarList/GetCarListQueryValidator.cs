using System;
using FluentValidation;

namespace Cars.Application.Cars.Queries.GetCarList
{
    public class GetCarListQueryValidator : AbstractValidator<GetCarListQuery>
    {
        public GetCarListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}

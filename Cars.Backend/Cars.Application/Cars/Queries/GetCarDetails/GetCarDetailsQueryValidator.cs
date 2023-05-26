using System;
using FluentValidation;

namespace Cars.Application.Cars.Queries.GetCarDetails
{
    public class GetCarDetailsQueryValidator : AbstractValidator<GetCarDetailsQuery>
    {
        public GetCarDetailsQueryValidator()
        {
            RuleFor(car => car.Id).NotEqual(Guid.Empty);
            RuleFor(car => car.UserId).NotEqual(Guid.Empty);
        }
    }
}

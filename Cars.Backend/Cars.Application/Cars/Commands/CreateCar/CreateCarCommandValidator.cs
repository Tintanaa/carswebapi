using System;
using FluentValidation;

namespace Cars.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(createCarCommand =>
                createCarCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createCarCommand =>
                createCarCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}

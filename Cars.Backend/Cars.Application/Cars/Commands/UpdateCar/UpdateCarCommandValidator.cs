using System;
using FluentValidation;

namespace Cars.Application.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
        {
            RuleFor(updateCarCommand => updateCarCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateCarCommand => updateCarCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateCarCommand => updateCarCommand.Title)
                .NotEmpty().MaximumLength(250);
        }
    }
}

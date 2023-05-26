using System;
using FluentValidation;

namespace Cars.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
    {
        public DeleteCarCommandValidator()
        {
            RuleFor(deleteCarCommand => deleteCarCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteCarCommand => deleteCarCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}

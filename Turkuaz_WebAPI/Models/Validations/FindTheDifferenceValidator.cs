using FluentValidation;
using Turkuaz_WebAPI.Models;

namespace Turkuaz_WebAPI.Models.Validations
{
	public class FindTheDifferenceValidator : AbstractValidator<FindTheDifferenceDTO>
	{
		public FindTheDifferenceValidator()
		{

			RuleFor(x => x.FirstArea).NotNull().WithMessage("FirstArea area could not be null!");

			RuleFor(x => x.SecondArea).NotNull().WithMessage("SecondArea area could not be null!");
		}
	}
}

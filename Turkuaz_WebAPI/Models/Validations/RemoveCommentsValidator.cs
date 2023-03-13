using FluentValidation;

namespace Turkuaz_WebAPI.Models.Validations
{
	public class RemoveCommentsValidator : AbstractValidator<RemoveCommentsDTO>
	{
		public RemoveCommentsValidator()
		{
			RuleFor(x => x.Source).NotNull().WithMessage("Source area could not be null!");
		}
	}

}

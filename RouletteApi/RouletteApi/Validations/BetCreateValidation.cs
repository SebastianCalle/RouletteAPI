using FluentValidation;
using RouletteApi.Dtos;

namespace RouletteApi.Validations
{
    public class BetCreateValidation : AbstractValidator<BetCreateDto>
    {
        public BetCreateValidation()
        {
            RuleFor(x => x.Color).Matches("^(red|black)$").WithMessage("Color Must be red or black");
            RuleFor(x => x.Number).GreaterThan(0).LessThan(36);
            RuleFor(x => x.Amount).GreaterThan(0).LessThan(10000);
        }

    }
}

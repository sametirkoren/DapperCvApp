
using CvApp.DTO.DTOs.AppUserDtos;
using FluentValidation;

namespace CvApp.Business.ValidationRules
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {

        public AppUserUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");
            
        }
    }
}

using CvApp.DTO.DTOs.SocialMediaIconDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.ValidationRules
{
    public class SocialMediaIconUpdateDtoValidator : AbstractValidator<SocialMediaIconUpdateDto>
    {
        public SocialMediaIconUpdateDtoValidator()
        {
            RuleFor(I => I.AppUserId).InclusiveBetween(1, int.MaxValue).WithMessage("AppUserId alanı boş geçilemez");
            RuleFor(I => I.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");

        }
    }
}

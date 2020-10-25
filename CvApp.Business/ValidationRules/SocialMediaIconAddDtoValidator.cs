using CvApp.DTO.DTOs.SocialMediaIconDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.ValidationRules
{
    public class SocialMediaIconAddDtoValidator : AbstractValidator<SocialMediaIconAddDto>
    {
        public SocialMediaIconAddDtoValidator()
        {
            RuleFor(I => I.AppUserId).InclusiveBetween(1, int.MaxValue).WithMessage("AppUserId alanı boş geçilemez");
            RuleFor(I => I.Icon).NotEmpty().WithMessage("İkon boş bırakılamaz");
            RuleFor(I => I.Link).NotEmpty().WithMessage("Link boş bırakılamaz");


        }
    }
}

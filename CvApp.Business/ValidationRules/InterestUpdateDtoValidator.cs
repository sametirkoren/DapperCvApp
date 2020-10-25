using CvApp.DTO.DTOs.InterestDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.ValidationRules
{
    public class InterestUpdateDtoValidator : AbstractValidator<InterestUpdateDto>
    {
        public InterestUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş geçilemez");
        }
    }
}

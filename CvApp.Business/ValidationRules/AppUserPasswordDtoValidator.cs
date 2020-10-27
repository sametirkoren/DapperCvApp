using CvApp.DTO.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.ValidationRules
{
    public class AppUserPasswordDtoValidator : AbstractValidator<AppUserPasswordDto>
    {
        public AppUserPasswordDtoValidator()
        {
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola boş geçilemez");
            RuleFor(I => I.ConfirmPassword).NotEmpty().WithMessage("Parola tekrar boş  geçilemez");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Parolalar uyuşmuyor");
        }
    }
}

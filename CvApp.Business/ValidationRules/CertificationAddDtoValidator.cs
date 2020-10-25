using CvApp.DTO.DTOs.CertificationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.ValidationRules
{
    public class CertificationAddDtoValidator : AbstractValidator<CertificationAddDto>
    {
        public CertificationAddDtoValidator()
        {
            RuleFor(I => I.Description).NotEmpty().WithMessage("Sertifika açıklama alanı boş geçilemez.");
        }
    }
}

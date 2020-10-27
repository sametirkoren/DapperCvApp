using AutoMapper;
using CvApp.DTO.DTOs.AppUserDtos;
using CvApp.DTO.DTOs.CertificationDtos;
using CvApp.DTO.DTOs.EducationDtos;
using CvApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvApp.Web.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserListDto, AppUser>();

            CreateMap<Certification, CertificationListDto>();
            CreateMap<CertificationListDto, Certification>();


            CreateMap<Certification, CertificationAddDto>();
            CreateMap<CertificationAddDto, Certification>();



            CreateMap<Certification, CertificationUpdateDto>();
            CreateMap<CertificationUpdateDto, Certification>();

            CreateMap<Education, EducationListDto>();
            CreateMap<EducationListDto, Education>();

            CreateMap<Education, EducationAddDto>();
            CreateMap<EducationAddDto, Education>();


            CreateMap<Education, EducationUpdateDto>();
            CreateMap<EducationUpdateDto, Education>();
        }
    }
}

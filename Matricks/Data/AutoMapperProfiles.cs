using AutoMapper;
using Matricks.DTOs;
using Matricks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matricks.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, BriefDTO>().ForMember(dest => dest.Url, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
            });
            CreateMap<User, UserDTO>().ForMember(dest => dest.Url, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
            });
        }
    }
}

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
            CreateMap<User, BriefDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}

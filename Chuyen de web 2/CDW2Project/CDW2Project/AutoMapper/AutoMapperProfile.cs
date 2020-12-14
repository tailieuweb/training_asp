using AutoMapper;
using CDW2Project.Models;
using DatabaseModel.CustomIdentityUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserAccount, PersonalUserViewModel>();
        }
    }
}

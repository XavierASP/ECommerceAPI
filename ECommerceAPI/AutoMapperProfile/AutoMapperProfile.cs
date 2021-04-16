using AutoMapper;
using ECommerceAPI.DTO;
using ECommerceAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Employee, EmployeeReadDTO>();
        }
    }
}

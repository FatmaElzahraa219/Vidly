using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Viidly.Models;
using Viidly.Dto;
namespace Viidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           Mapper.CreateMap<Customer,CustomerDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore()).ForMember(m =>m.NumInStock,opt =>opt.Ignore());
        }
    }
}
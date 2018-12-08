using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Dtos;
using VidlyPrototype.Models;

namespace VidlyPrototype.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Customers 
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipTypes, MembershipTypesDto>();

            //Movies
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<MovieGenres, MovieGenresDto>();

            //Rentals
            Mapper.CreateMap<Rentals, RentalsDto>();
            Mapper.CreateMap<RentalsDto, Rentals>();
        }
    }
}
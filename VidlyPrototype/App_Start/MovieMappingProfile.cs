using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyPrototype.Dtos;
using VidlyPrototype.Models;

namespace VidlyPrototype.App_Start
{
    public class MovieMappingProfile:Profile
    {
        public MovieMappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ngCookingWebApi.Models;
using ngCookingWebApi.Dtos;
using AutoMapper.Configuration;

namespace ngCookingWebApi.App_Start
{
    public class MappingProfile: Profile
    {
        public static void Run()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile<MappingProfile>();
            
        }
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto,Ingredient>();
        }
    }
}
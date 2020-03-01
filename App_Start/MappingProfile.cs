using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ngCookingWebApi.Models;
using ngCookingWebApi.Dtos;
using AutoMapper.Configuration;

namespace ngCookingWebApi
{
    public class MappingProfile: Profile
    {
        public static MapperConfiguration GetConfiguration()
        {
           return new MapperConfiguration(cfg=>cfg.AddProfile<MappingProfile>());

        }
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto,Ingredient>();
            CreateMap<CategorieIngredient, CategorieIngredientDto>();
            CreateMap<CategorieIngredientDto, CategorieIngredient>();
            CreateMap<Recette, RecetteDto>();
            CreateMap<RecetteDto, Recette>();
            
        }
    }
}
using AutoMapper;
using FinancesOrganizer.Models;
using FinancesOrganizer.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<CreateRecipeDTO, Recipe>();
            CreateMap<Recipe, ReadRecipeDTO>();
            CreateMap<UpdateRecipeDTO, Recipe>();
        }
    }
}

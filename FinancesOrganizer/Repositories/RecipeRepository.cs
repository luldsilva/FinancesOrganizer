using AutoMapper;
using FinancesOrganizer.Data;
using FinancesOrganizer.Interfaces;
using FinancesOrganizer.Models;
using FinancesOrganizer.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Repositories
{
    public class RecipeRepository : ControllerBase, IUtil
    {
        private IMapper _mapper;
        private DataContext _context;

        public RecipeRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult RegisterRecipe(CreateRecipeDTO recipeDTO)
        {
            Recipe recipe = _mapper.Map<Recipe>(recipeDTO);
            IsDuplicateVerify(recipeDTO.Description);

            var res = _context.AddItemInDb(recipe);

            //Pesquisar se bad request é o melhor cod de erro ou se tem um melhor
            if (res.IsFailed) return BadRequest(res.Errors);
            return Ok(res.Successes);

        }

        //Verificar se isso aqui funciona
        public void IsDuplicateVerify(string description)
        {
            bool returnMessage = false;

            if (_context.Recipe.Any(x => x.Description == description))
            {
                returnMessage = true;
            }

            if (returnMessage == true)
            {
                BadRequest("Mensagem duplicada!");
            }
        }
    }
}

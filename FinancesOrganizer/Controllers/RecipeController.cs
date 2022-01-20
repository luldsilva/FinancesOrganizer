using AutoMapper;
using FinancesOrganizer.Data;
using FinancesOrganizer.Models;
using FinancesOrganizer.Models.DTOS;
using FinancesOrganizer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RecipeController : ControllerBase
    {
        private RecipeRepository _repo;
        private DataContext _context;
        private IMapper _mapper;

        public RecipeController(DataContext context, IMapper mapper)
        {
            //_repo = repo;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Recipe([FromBody] CreateRecipeDTO recipeDTO)
        {
            Recipe recipe = _mapper.Map<Recipe>(recipeDTO);
            //_repo.RegisterRecipe(recipe);
            _context.Recipe.Add(recipe);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult ListRecipe()
        {
            return Ok(_context.Recipe);
        }

        [HttpGet("{id}")]
        public IActionResult RecoveryRecipe(long id)
        {
            Recipe recipe = _context.Recipe.FirstOrDefault(recipe => recipe.Id == id);
            if(recipe == null)
            {
                return NotFound();
            }
            ReadRecipeDTO recipeDTO = _mapper.Map<ReadRecipeDTO>(recipe);
            return Ok(recipeDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(long id, [FromBody] UpdateRecipeDTO newRecipeDTO)
        {
            Recipe recipe = _context.Recipe.FirstOrDefault(recipe => recipe.Id == id);
            if(recipe == null)
            {
                return NotFound();
            }

            _mapper.Map(newRecipeDTO, recipe);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(long id)
        {
            Recipe recipe = _context.Recipe.FirstOrDefault(recipe => recipe.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Remove(recipe);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

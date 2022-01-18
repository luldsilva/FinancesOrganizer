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

    public class FinancesController : ControllerBase
    {
        private RecipeRepository _repo;
        private DataContext _context;

        public FinancesController(DataContext context)
        {
            //_repo = repo;
            _context = context;
        }

        [HttpPost]
        public IActionResult Recipe([FromBody] Recipe recipe)
        {
            //_repo.RegisterRecipe(recipe);
            _context.Recipe.Add(recipe);
            _context.SaveChanges();
            return Ok();
        }
    }
}

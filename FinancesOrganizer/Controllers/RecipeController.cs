using AutoMapper;
using FinancesOrganizer.Data;
using FinancesOrganizer.Enum;
using FinancesOrganizer.Models;
using FinancesOrganizer.Models.DTOS;
using FinancesOrganizer.Repositories;
using FinancesOrganizer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace FinancesOrganizer.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RecipeController : ControllerBase
    {
        private RecipeRepository _repo;
        private DataContext _context;
        private IMapper _mapper; //Isso tem que sumir
        private IUtil _util;

        public RecipeController(DataContext context, IMapper mapper, IUtil util)
        {
            _context = context;
            _mapper = mapper; //Isso tem que sumir
            _util = util;
        }

        [HttpPost]
        public IActionResult Recipe([FromBody] CreateRecipeDTO recipeDTO)
        {
            var msgReturn = _util.RegisterRecipe(recipeDTO);
            //Fazer condicional para o retorno positivo ou negativo
            return Ok();
        }

        [HttpGet]
        public IActionResult ListRecipe([FromQuery] string descriptionRecipe)
        {
            List<Recipe> recipeList = _context.Recipe.ToList();
            if (recipeList is null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(descriptionRecipe))
            {
                IEnumerable<Recipe> query = from recipe in recipeList
                                            where recipe.Description == descriptionRecipe
                                            select recipe;
                recipeList = query.ToList();
            }
            return Ok(recipeList);
        }

        [HttpGet("{ano}/{mes}")]
        public IActionResult ListRecipePerMonth(long ano, int mes)
        {
            List<Recipe> recipeList = _context.Recipe.ToList();
            if (recipeList is null)
            {
                return NotFound();
            }

            IEnumerable<Recipe> query = from recipe in recipeList
                                        where recipe.Date.Year == ano &&
                                        recipe.Date.Month == mes
                                        select recipe;
            recipeList = query.ToList();


            return Ok(recipeList);
        }

        [HttpGet("/resumo/{ano}/{mes}")]
        public IActionResult ListResumePerMonth(long ano, int mes, CategoryExpenseEnum cat)
        {
            Double totalValueRecipe = 0;
            Double totalValueExpense = 0;
            Double totalValuePerCategory = 0;
            Double totalValueExpensePerCat = 0;
            Double totalBalance;

            List<Recipe> recipeList = _context.Recipe.ToList();
            List<Expense> expenseList = _context.Expense.ToList();
            Balance balance = new Balance();

            IEnumerable<Double> queryRecipe = from recipe in recipeList
                                              where recipe.Date.Year == ano &&
                                              recipe.Date.Month == mes
                                              select recipe.Value;
            List<Double> receiveTest = queryRecipe.ToList();

            /*Isso vira uma funcao*/
            for (int i = 0; i < receiveTest.Count; i++)
            {
                totalValueRecipe = totalValueRecipe + receiveTest[i];
            }

            balance.TotalValueRecipe = totalValueRecipe;

            IEnumerable<ReadExpenseDTO> queryExpense = from expense in expenseList
                                                       where expense.Date.Year == ano &&
                                                       expense.Date.Month == mes
                                                       select new ReadExpenseDTO()
                                                       {
                                                           Value = expense.Value,
                                                           Category = expense.Category
                                                       };
            List<ReadExpenseDTO> receiveTestExpense = queryExpense.ToList();

            /*Isso vira uma funcao*/
            for (int i = 0; i < receiveTestExpense.Count; i++)
            {
                totalValueExpense = totalValueExpense + receiveTestExpense[i].Value;
            }

            balance.TotalValueExpense = totalValueExpense;



            /*Isso vira funcao*/
            totalBalance = totalValueRecipe - totalValueExpense;

            balance.TotalValueBalance = totalBalance;

            IEnumerable<ReadExpenseDTO> queryExpensePerCat = from expense in expenseList
                                                             where expense.Date.Year == ano &&
                                                             expense.Date.Month == mes &&
                                                             expense.Category == cat
                                                             select new ReadExpenseDTO()
                                                             {
                                                                 Value = expense.Value,
                                                                 Category = expense.Category
                                                             };
            List<ReadExpenseDTO> receiveTestExpensePerCat = queryExpensePerCat.ToList();

            for (int i = 0; i < receiveTestExpensePerCat.Count; i++)
            {
                totalValueExpensePerCat = totalValueExpensePerCat + receiveTestExpensePerCat[i].Value;
            }

            balance.TotalValuePerCategory = totalValueExpensePerCat;

            //return Ok(balance.TotalValuePerCategory);


            return Ok(balance);

        }

        [HttpGet("{id}")]
        public IActionResult RecoveryRecipe(long id)
        {
            Recipe recipe = _context.Recipe.FirstOrDefault(recipe => recipe.Id == id);
            if (recipe == null)
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
            if (recipe == null)
            {
                return NotFound();
            }

            _mapper.Map(newRecipeDTO, recipe);
            _context.UpdateItemInDb();
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

            _context.DeleteItemInDb(recipe);
            return NoContent();
        }
    }
}

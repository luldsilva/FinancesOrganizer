using FinancesOrganizer.Data;
using FinancesOrganizer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Repositories
{
    public class RecipeRepository : IUtil
    {
        private DataContext _context;

        public RecipeRepository(DataContext context)
        {
            _context = context;
        }


        public string RegisterRecipe(Recipe recipe)
        {
            try
            {
                string result;
                _context.Recipe.Add(recipe);
                _context.SaveChanges();
                result = "Sucesso";
                return result;
            }
            catch(NullReferenceException ex)
            {
                throw;
            }
        }
    }
}

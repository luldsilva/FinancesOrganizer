using FinancesOrganizer.Data;
using FinancesOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Repositories
{
    public class RecipeRepository
    {
        private DataContext _context;

        public RecipeRepository(DataContext context)
        {
            _context = context;
        }

        public void RegisterRecipe(Recipe recipe)
        {
            _context.Recipe.Add(recipe);
            _context.SaveChanges();
        }
    }
}

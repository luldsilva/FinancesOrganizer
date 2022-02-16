using FinancesOrganizer.Models;
using FinancesOrganizer.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Interfaces
{
    public interface IUtil
    {
        public IActionResult RegisterRecipe(CreateRecipeDTO recipe);
    }
}

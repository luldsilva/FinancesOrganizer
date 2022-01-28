using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Models
{
    public class Balance
    {
        public Double TotalValueRecipe { get; set; }
        public Double TotalValueExpense { get; set; }
        public Double TotalValueBalance { get; set; }
        public Double TotalValuePerCategory { get; set; }
    }
}

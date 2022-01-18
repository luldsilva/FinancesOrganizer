using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Models.DTOS
{
    public class ExpenseDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public Double Value { get; set; }
        public DateTime Date { get; set; }
    }
}

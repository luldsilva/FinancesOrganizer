using FinancesOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base (opt)
        {

        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Expense> Expense { get; set; }
    }
}

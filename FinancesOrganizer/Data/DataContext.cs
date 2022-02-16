using FinancesOrganizer.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
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

        public Result AddItemInDb(Recipe recipe)
        {
            Recipe.Add(recipe);
            SaveChanges();
            return Result.Ok();
        }

        public void UpdateItemInDb()
        {
            SaveChanges();
        }

        public void DeleteItemInDb(Recipe recipe)
        {
            Remove(recipe);
            SaveChanges();
        }
    }
}

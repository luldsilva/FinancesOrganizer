using FinancesOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Data
{
    public class WalletContext : DbContext
    {
        public WalletContext(DbContextOptions<WalletContext> opt) : base (opt)
        {

        }

        public DbSet<User> Wallets { get; set; }
    }
}

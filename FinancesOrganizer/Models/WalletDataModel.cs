using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Models
{
    public class WalletDataModel
    {
        [Required(ErrorMessage = "O campo nome do títular é obrigatório")]
        public string Nome_titular { get; set; }

        [Required(ErrorMessage = "O campo saldo é obrigatório")]
        public double Saldo { get; set; }
    }
}

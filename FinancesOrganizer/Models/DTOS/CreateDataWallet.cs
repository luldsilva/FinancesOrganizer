using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Models.DTOS
{
    public class CreateDataWallet
    {
        [Required(ErrorMessage ="O campo nome do títular é obrigatório")]
        public string Nome_titular { get; private set; }
        
        [Required(ErrorMessage ="O campo saldo é obrigatório")]
        public double Saldo { get; private set; }
    }
}

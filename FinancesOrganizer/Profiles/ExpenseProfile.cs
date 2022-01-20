using AutoMapper;
using FinancesOrganizer.Models;
using FinancesOrganizer.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<CreateExpenseDTO, Expense>();
            CreateMap<Expense, ReadExpenseDTO>();
            CreateMap<UpdateExpenseDTO, Expense>();
        }
    }
}

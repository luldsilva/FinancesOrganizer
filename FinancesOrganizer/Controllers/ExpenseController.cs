using AutoMapper;
using FinancesOrganizer.Data;
using FinancesOrganizer.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancesOrganizer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public ExpenseController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Expense([FromBody] CreateExpenseDTO expenseDTO)
        {
            Expense expense = _mapper.Map<Expense>(expenseDTO);
            _context.Expense.Add(expense);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult ListExpense()
        {
            return Ok(_context.Expense);
        }

        [HttpGet("{id}")]
        public IActionResult RecoveryExpense(long id)
        {
            Expense expense = _context.Expense.FirstOrDefault(expense => expense.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            ReadExpenseDTO expenseDTO = _mapper.Map<ReadExpenseDTO>(expense);
            return Ok(expenseDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExpense(long id, [FromBody] UpdateExpenseDTO newExpenseDTO)
        {
            Expense expense = _context.Expense.FirstOrDefault(expense => expense.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            _mapper.Map(newExpenseDTO, expense);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(long id)
        {
            Expense expense = _context.Expense.FirstOrDefault(expense => expense.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Remove(expense);
            _context.SaveChanges();
            return NoContent();
        }

    }
}

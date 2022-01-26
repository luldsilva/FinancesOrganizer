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

            if (_context.Expense.Any(x => x.Description == expenseDTO.Description))
            {
                return BadRequest("Descrição duplicada!");
            }

            if (expenseDTO.Category == 0)
            {
                expense.Category = Enum.CategoryExpenseEnum.Others;
            }

            _context.Expense.Add(expense);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult ListExpense([FromQuery] string descriptionExpense)
        {
            List<Expense> expenseList = _context.Expense.ToList();
            if(expenseList is null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(descriptionExpense))
            {
                IEnumerable<Expense> query = from expense in expenseList
                                            where expense.Description == descriptionExpense
                                            select expense;
                expenseList = query.ToList();
            }
            return Ok(expenseList);
        }

        [HttpGet("{ano}/{mes}")]
        public IActionResult ListExpensePerMonth(long ano, int mes)
        {
            List<Expense> expenseList = _context.Expense.ToList();
            if (expenseList is null)
            {
                return NotFound();
            }

            IEnumerable<Expense> query = from expense in expenseList
                                        where expense.Date.Year == ano &&
                                        expense.Date.Month == mes
                                        select expense;
            expenseList = query.ToList();


            return Ok(expenseList);
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

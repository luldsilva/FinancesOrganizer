using FinancesOrganizer.Models;
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

    public class FinController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("API respondendo!");
        }
    }
}

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

    public class FinancesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("API respondendo!");
        }

        [HttpPost]
        public IActionResult PostTest([FromBody] User body)
        {
            var testeReceiver = body;
            return Ok(body);
        }
    }
}

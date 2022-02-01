using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private RegisterService _registerService;
        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserDTO createDTO)
        {
            Result result = _registerService.RegisterUser(createDTO);
            if (result.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}

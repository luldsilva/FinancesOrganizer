using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result RegisterUser(RegisterUserDTO createDTO)
        {
            User user = _mapper.Map<User>(createDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);

            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, createDTO.Password);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}

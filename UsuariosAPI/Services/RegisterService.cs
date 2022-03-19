using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsersAPI.Data.Requests;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }


        public Result RegisterUser(RegisterUserDTO createDTO)
        {
            User user = _mapper.Map<User>(createDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            var resultIdentity = _userManager.CreateAsync(userIdentity, createDTO.Password).Result;
            _userManager.AddToRoleAsync(userIdentity, "regular");
            if (resultIdentity.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.SendEmail(new[] { userIdentity.Email}, "Link de Ativação", userIdentity.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            } 
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result ActiveAcountUser(ActiveAcountRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(u => u.Id == request.UserId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodeActivation).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}

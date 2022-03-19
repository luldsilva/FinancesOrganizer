using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAPI.Data.Requests;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultIdentity.Result.Succeeded) 
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user =>
                    user.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result EffectingResetPassword(EffectingResetRequest request)
        {
            IdentityUser<int> identityUser = RecoverUserPerEmail(request.Email);
            IdentityResult resultIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (resultIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Houve um erro na operação.");
        }

        public Result SolicitResetRequest(SolicitResetRequest request)
        {
            IdentityUser<int> identityUser = RecoverUserPerEmail(request.Email);
            if (identityUser != null)
            {
                string resetCode = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(resetCode);
            }

            return Result.Fail("Falha ao solicitar redefinição");
        }

        private IdentityUser<int> RecoverUserPerEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}

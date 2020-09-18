using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Enums;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Login(LoginModel model, [FromServices] UsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha);
                                        
                    if (usuario != null)
                    {
                        return SignIn(usuario.Email, usuario.Permissao.ToString());
                    }
                    else if (model.Email.Equals("admin@impacta.com.br") && model.Senha.Equals("admin"))
                    {
                        return SignIn(model.Email, Permissao.Administrador.ToString());
                    }
                    else
                    {
                        throw new Exception("Usuário inválido. Acesso Negado.");
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync
           (CookieAuthenticationDefaults.AuthenticationScheme);
         
            return RedirectToAction("Login");
        }

        private IActionResult SignIn(string nomeDeUsuario, string perfilAcesso)
        {
            var identity = new ClaimsIdentity(new[]
            { 
                new Claim(ClaimTypes.Name, nomeDeUsuario), 
                new Claim(ClaimTypes.Role, perfilAcesso) },
                CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync
              (CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(identity));
                return RedirectToAction("Consulta", "Tarefa");
        }
    }
}

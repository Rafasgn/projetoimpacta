using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Enums;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(UsuarioCadastroModel model,
          [FromServices] UsuarioRepository usuarioRepository)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    if (usuarioRepository.GetByEmail(model.Email) != null)
                    {
                        
                        throw new Exception
                       ("O email informado já encontra-se cadastrado.");
                    }

                    var usuario = new Usuario();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = model.Senha;
                    usuario.Permissao = (Permissao) model.Permissao;

                    usuarioRepository.Insert(usuario);


                    TempData["MensagemSucesso"] = $"Usuário  {usuario.Nome}, cadastrado com sucesso.";

                    ModelState.Clear();
                }

                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }

            } 
            return View();
        }

        public IActionResult Consulta(
            [FromServices] UsuarioRepository usuarioRepository)
        {
            var lista = new List<Usuario>();

            try
            {
                lista = usuarioRepository.GetAll();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(lista);
        }

    }
}


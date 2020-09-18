using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Enums;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(TarefaCadastroModel model,
            [FromServices] TarefaRepository tarefaRepository,
            [FromServices] UsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = usuarioRepository.GetByEmail(User.Identity.Name);

                    var tarefa = new Tarefa();
                    tarefa.Titulo = model.Titulo;
                    tarefa.Status = StatusTarefa.Aberta;
                    tarefa.IdUsuario = usuario.IdUsuario;

                    tarefaRepository.Insert(tarefa);

                    TempData["MensagemSucesso"] = $"Tarefa {tarefa.Titulo}, cadastrado com sucesso.";
                    return RedirectToAction("Consulta");
                }

                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }

            }
            return View();
        }

        public IActionResult Consulta(
            [FromServices] TarefaRepository tarefaRepository,
            [FromServices] UsuarioRepository usuarioRepository)
        {
            var lista = new List<Tarefa>();

            try
            {
                var usuario = usuarioRepository.GetByEmail(User.Identity.Name);
                
                if(usuario != null)
                {
                    lista = tarefaRepository.GetAll(usuario.IdUsuario);
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(lista);
        }

        public IActionResult Exclusao(int id, 
            [FromServices]UsuarioRepository usuarioRepository, 
            [FromServices]TarefaRepository tarefaRepository)
        {
            var usuario = usuarioRepository.GetByEmail(User.Identity.Name);
            try
            {
                var tarefa = tarefaRepository.GetById(id);

                if (tarefa.IdUsuario == usuario.IdUsuario)
                {
                    tarefaRepository.Delete(tarefa);

                    TempData["MensagemSucesso"] = "Tarefa excluído com sucesso.";
                }

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return RedirectToAction("Consulta");
        }

        public IActionResult Edicao(int id, 
            [FromServices] UsuarioRepository usuarioRepository, 
            [FromServices] TarefaRepository tarefaRepository)
        {
            var usuario = usuarioRepository.GetByEmail(User.Identity.Name);
            var model = new TarefaEdicaoModel();
            try
            {

                var tarefa = tarefaRepository.GetById(id);

                
                if (tarefa.IdUsuario == usuario.IdUsuario)
                {
                    
                    model.IdTarefa = tarefa.IdTarefa;
                    model.Titulo = tarefa.Titulo;
                  }
                else
                {
                    return RedirectToAction("ConsultaTarefa");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(TarefaEdicaoModel model,
         [FromServices] TarefaRepository tarefaRepository,
         [FromServices] UsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = usuarioRepository.GetByEmail(User.Identity.Name);
                    var tarefa = tarefaRepository.GetById(model.IdTarefa);

                    tarefa.Titulo = model.Titulo;
                    tarefaRepository.Update(tarefa);

                    TempData["MensagemSucesso"] = $"Tarefa {tarefa.Titulo}, atualizada com sucesso.";

                    return RedirectToAction("Consulta");
                }

                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }

            }
            return View();
        }


        public IActionResult AlterarStatus(int id,
            [FromServices] UsuarioRepository usuarioRepository,
            [FromServices] TarefaRepository tarefaRepository)
        {
            var usuario = usuarioRepository.GetByEmail(User.Identity.Name);
            var model = new TarefaEdicaoModel();
            try
            {

                var tarefa = tarefaRepository.GetById(id);

                if (tarefa.Status == StatusTarefa.Aberta)
                    tarefa.Status = StatusTarefa.Concluida;
                else
                    tarefa.Status = StatusTarefa.Aberta;

                tarefaRepository.Update(tarefa);

                TempData["MensagemSucesso"] = "Status atualizado com sucesso";
                return RedirectToAction("Consulta");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }

    }
}

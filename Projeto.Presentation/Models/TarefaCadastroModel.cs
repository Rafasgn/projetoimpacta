using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Projeto.Infra.Data.Enums;

namespace Projeto.Presentation.Models
{
    public class TarefaCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o título da Tarefa.")]
        public string Titulo { get; set; }
    }
}

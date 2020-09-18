using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class TarefaEdicaoModel
    {
        public int IdTarefa { get; set; }

        [Required(ErrorMessage = "Por favor, informe o título da Tarefa.")]
        public string Titulo { get; set; }
    }
}

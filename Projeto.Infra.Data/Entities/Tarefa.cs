using Projeto.Infra.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public StatusTarefa Status { get; set; }
        public int IdUsuario { get; set; }

        public Tarefa()
        {

        }

        public Tarefa(int idTarefa, string titulo, StatusTarefa status, int idUsuario)
        {
            IdTarefa = idTarefa;
            Titulo = titulo;
            Status = status;
            IdUsuario = idUsuario;
        }

        public Usuario Usuario { get; set; }
    }
}

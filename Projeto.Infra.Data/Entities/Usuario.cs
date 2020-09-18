using Projeto.Infra.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Permissao Permissao { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string email, string senha, Permissao permissao)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            Permissao = permissao;
        }

        public List<Tarefa> Tarefa { get; set; }
    }
}

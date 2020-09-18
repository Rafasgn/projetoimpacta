using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Projeto.Infra.Data.Enums;

namespace Projeto.Presentation.Models
{
    public class UsuarioCadastroModel
    {
        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1}    caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
       [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
       [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}    caracteres.")]
       [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
       [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string SenhaConfirmacao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a permissão de acesso.")]
        public Permissao? Permissao { get; set; }
    }
}

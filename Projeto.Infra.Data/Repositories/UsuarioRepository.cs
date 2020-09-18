using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Usuario GetByEmail(string email)
        {
            return dataContext.Set<Usuario>().FirstOrDefault(u => u.Email == email);
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            return dataContext.Set<Usuario>().FirstOrDefault(u => u.Email ==
            email && u.Senha == senha);
        }
    }
}

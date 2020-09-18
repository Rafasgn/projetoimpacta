using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRpository
    {
        private readonly DataContext dataContext;
        public TarefaRepository(DataContext dataContext) : base (dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<Tarefa> GetAll(int idUsuario)
        {
            return dataContext.Tarefa
                    .Where(t => t.IdUsuario == idUsuario)
                    .ToList();
        }
    }
}

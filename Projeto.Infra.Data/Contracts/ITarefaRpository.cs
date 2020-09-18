using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contracts
{
   public interface ITarefaRpository : IBaseRepository<Tarefa>
    {
        List<Tarefa> GetAll(int idUsuario);

    }
}

using FourTask_Lucas.Models;
using System.Linq.Expressions;

namespace FourTask_Lucas.Repositories
{
    public interface ITarefaRepository
    {
        public IList<Tarefa> Listar();
        public void Adicionar(Tarefa tarefa);
        public void Remover(int id);
        public void Atualizar(Tarefa tarefa);

        public Tarefa BuscarPorId(int id);
        public void Salvar();
    }
}

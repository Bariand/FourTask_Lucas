using FourTask_Lucas.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FourTask_Lucas.Repositories

{
    public class TarefaRepository : ITarefaRepository
    {
        private Areas.Identity.Data.FourTask_LucasContext _context;

        public TarefaRepository(Areas.Identity.Data.FourTask_LucasContext context)
        {
            _context = context;
        }

        public IList<Tarefa> Listar()
        {
            return _context.Tarefas.ToList();
        }

        public void Adicionar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
        }

        public void Remover(int id)
        {
            Tarefa tarefa = _context.Tarefas.Find(id);
            _context.Tarefas.Remove(tarefa);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
        }

        public Tarefa BuscarPorId(int id)
        {
            return _context.Tarefas.Where(a => a.TarefaId == id).FirstOrDefault();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

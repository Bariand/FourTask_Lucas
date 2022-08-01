using FourTask_Lucas.Areas.Identity.Data;
using FourTask_Lucas.Models;
using Microsoft.EntityFrameworkCore;

namespace FourTask_Lucas.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {
        private Areas.Identity.Data.FourTask_LucasContext _context;

        public EquipeRepository(Areas.Identity.Data.FourTask_LucasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
        }

        public IList<Equipe> Listar()
        {
            return _context.Equipes.ToList();
        }

        public Equipe BuscarPorId(Usuario user)
        {
            return _context.Equipes.Where(e => e.EquipeId == user.EquipeId).FirstOrDefault();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

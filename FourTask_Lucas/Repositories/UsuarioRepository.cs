using FourTask_Lucas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FourTask_Lucas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private Areas.Identity.Data.FourTask_LucasContext _context;
        public UsuarioRepository(Areas.Identity.Data.FourTask_LucasContext context)
        {
            _context = context;
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

using FourTask_Lucas.Areas.Identity.Data;

namespace FourTask_Lucas.Repositories
{
    public interface IUsuarioRepository
    {
        public void Atualizar(Usuario usuario);
        public void Salvar();
    }
}

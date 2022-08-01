using FourTask_Lucas.Areas.Identity.Data;
using FourTask_Lucas.Models;

namespace FourTask_Lucas.Repositories
{
    public interface IEquipeRepository
    {
        public IList<Equipe> Listar();
        void Cadastrar(Equipe equipe);
        void Salvar();
        Equipe BuscarPorId(Usuario user);
    }
}

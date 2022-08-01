using FourTask_Lucas.Models;
namespace FourTask_Lucas.ViewModel
{
    public class EquipeTarefaModel
    {
        public Tarefa Tarefa { get; set; }
        public IEnumerable<Tarefa> TarefasLista { get; set; }
        public Equipe Equipe { get; set; }
        public int EquipeId { get; set; }
        public ICollection<Tarefa>? Tarefas { get; set; }

    }
}

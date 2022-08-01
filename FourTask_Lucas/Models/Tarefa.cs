using FourTask_Lucas.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourTask_Lucas.Models
{
    [Table("Tbl_Tarefa")]
    public class Tarefa
    {
        [Column("Id"), Required]
        public int TarefaId { get; set; }
        [Required(ErrorMessage = "Você precisa inserir um título para a tarefa.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Você precisa inserir uma descrição para a tarefa.")]
        [StringLength(120)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Você precisa inserir uma Data Limite para a tarefa.")]
        public DateTime DataLimite { get; set; }
        public DateTime DataCriacao { get; set; }

        //relação N : 1
        public Usuario? Usuario { get; set; }
        public string? UsuarioId { get; set; }

        //relação N : 1
        public Equipe? Equipe { get; set; }
        public int? EquipeId { get; set; }

        public Tarefa()
        {
            DataCriacao = DateTime.Now;
        }
    }
}

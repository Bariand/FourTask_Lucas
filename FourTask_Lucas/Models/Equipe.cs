using FourTask_Lucas.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourTask_Lucas.Models
{
    [Table("Tbl_Equipe")]
    public class Equipe
    {
        [Column("Id"), Required]
        public int EquipeId { get; set; }
        [Required(ErrorMessage = "Você precisa inserir um nome para a equipe.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Você precisa inserir uma senha para a equipe.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Você precisa inserir uma descrição para a equipe.")]
        [StringLength(60)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Você precisa definir a área de atuação da equipe.")]
        public AreaAtuacao AreaAtuacao { get; set; }
        public DateTime DataCriacao { get; set; }

        //relação 1 : N
        public ICollection<Usuario>? Usuarios { get; set; }

        //relação 1 : N
        public ICollection<Tarefa>? Tarefas { get; set; }

        //Construtor
        public Equipe()
        {
            DataCriacao = DateTime.Now;
        }
    }
    public enum AreaAtuacao
    {
        Web, Mobile, FrontEnd, BackEnd, FullStack, Gestao, Outros
    }
}

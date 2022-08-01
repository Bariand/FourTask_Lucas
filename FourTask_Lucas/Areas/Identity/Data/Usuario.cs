using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FourTask_Lucas.Models;
using Microsoft.AspNetCore.Identity;

namespace FourTask_Lucas.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
[Table("Tbl_Usuario")]
public class Usuario : IdentityUser
{
    //[Column("Id"), Required]
    //public int UsuarioId { get; set; }
    //[Required]
    //public string Email { get; set; }
    //[Required]
    //public string Senha { get; set; }
    public DateTime? DataNascimento { get; set; }

    //relação 1 : N

    public ICollection<Tarefa>? Tarefas { get; set; }

    //relação N : 1
    public Equipe? Equipe { get; set; }
    public int? EquipeId { get; set; }
}


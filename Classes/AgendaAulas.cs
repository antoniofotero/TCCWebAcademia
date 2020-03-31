using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAcademia.Classes
{
    public class AgendaAulas
    {
       [Key]
        public int CodigoAgendamento { get; set; }
        [Required]

        public List<Aluno> AlunosMatriculados { get; set; }
        [Required]
        public Instrutor InstrutorAula { get; set; }
        [Required]
        public Aula AulaAgenda { get; set; }
        public DateTime HoraInicio { get; set; }
        public int DuracaoMinutos { get; set; }
    }
}
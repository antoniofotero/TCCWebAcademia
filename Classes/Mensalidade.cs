using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebAcademia.Classes
{
    public class Mensalidade
    {
        [Key]
        public int CodigoMensalidade { get; set; }
        public Plano PlanoMensalidade { get; set; }
        public Utils.Mes MesReferencia { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool PagamentoConcluido { get; set; }
        [Required]
        public Aluno AlunoMensalidade { get; set; }
    }
}
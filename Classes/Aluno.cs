using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAcademia.Classes
{
    public class Aluno
    {
        public int CPF { get; set; }
        [Key]
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco EnderecoAluno { get; set; }
        //public Plano AlunoPlano { get; set; }
        public Mensalidade AlunoMensalidade { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebAcademia.Classes
{
    public class Plano
    {
        [Key]
        public int Codigo { get; set; }
        public double ValorMensal {get; set;}
        List<Aula> AulasPlano { get; set; }

    }
}
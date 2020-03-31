using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebAcademia.Classes
{
    public class Instrutor
    {
        public string Nome { get; set; }
        [Key]
        public int Matricula { get; set; }

    }
}
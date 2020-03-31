using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebAcademia.Classes
{
    public class Aula
    {
        [Key]
        public int CodigoAula { get; set; }
        public string NomeAula { get; set; }
        public int FrequenciaSemanal { get; set; }

    }
}
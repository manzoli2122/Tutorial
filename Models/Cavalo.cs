using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tutorial.Models
{
    public class Cavalo
    {

        public int ID { get; set; }


        [Required]
        [Index(IsUnique = true)]
        public String Nome { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] 
        [DataType(DataType.Date, ErrorMessage = "Uma data válida deve ser informada!")]
        [Display(Name = "Nascimento")]
        public DateTime Nascimento { get; set; }


        [Required]
        [Index(IsUnique = true)]
        public int Numero { get; set; }




        public bool Ativo { get; set; }



    }
}
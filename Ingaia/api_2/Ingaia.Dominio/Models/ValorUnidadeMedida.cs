using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ingaia.Dominio.Models
{
    public class ValorUnidadeMedida : BaseEntity
    {

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string unidadeMedida { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        [Range(10, 10000, ErrorMessage = "Este campo deve ter um valor entre 10 e 10.000")]
        public double valor { get; set; }
    }
}
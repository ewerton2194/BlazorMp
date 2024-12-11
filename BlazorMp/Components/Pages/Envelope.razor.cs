using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorMp.Components.Pages
{
    public partial class Envelope
    {
       
        private double pesoCubico;

        [Required(ErrorMessage = "Largura é obrigatória.")]
        [Range(11, 60, ErrorMessage = "Largura deve ser entre 11cm e 60cm.")]
        public double Largura { get; set; }

        [Required(ErrorMessage = "Comprimento é obrigatória.")]
        [Range(16, 60, ErrorMessage = "Comprimento deve ser entre 16cm e 60cm.")]
        public double Comprimento { get; set; }

        [Required(ErrorMessage = "Peso é obrigatório.")]
        [Range(00001, 30000, ErrorMessage = "Peso deve ser entre 0,01g e 30.000g.")]
        public double Peso { get; set; }


        public string EnvelopeValue { get; set; }

    }
}


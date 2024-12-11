using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorMp.Components.Pages
{
    public partial class Caixa
    {
        private double pesoCubico;

        private void CalcularPesoCubico()
        {
           //Fórmula para calcular o peso cúbico: (Altura * Largura * Comprimento) / 6000
           pesoCubico = Altura * Largura * Comprimento / 6000.0;
        }

        [Required(ErrorMessage = "Altura é obrigatória.")]
        [Range(1, 100, ErrorMessage = "Altura deve ser entre 1cm e 100cm.")]
        public double Altura { get; set; }

        [Required(ErrorMessage = "Largura é obrigatória.")]
        [Range(8, 100, ErrorMessage = "Largura deve ser entre 8cm e 100cm.")]
        public double Largura { get; set; }

        [Required(ErrorMessage = "Comprimento é obrigatória.")]
        [Range(13, 100, ErrorMessage = "Comprimento deve ser entre 13cm e 100cm.")]
        public double Comprimento { get; set; }

        [Required(ErrorMessage = "Peso é obrigatório.")]
        [Range(00001, 30000, ErrorMessage = "Peso deve ser entre 0,01g e 30.000g.")]
        public double Peso { get; set; }


        public string CaixaValue { get; set; }
    }
}

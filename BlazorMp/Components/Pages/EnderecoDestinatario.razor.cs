using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMp.Components.Pages
{
    public partial class EnderecoDestinatario
    {
        public EnderecoDestinatario()
        {

        }
    }

    public class DestinatarioModel
    {
        [Required(ErrorMessage = "O nome do remetente é obrigatório.")]
        [StringLength(50, ErrorMessage = "O remetente pode conter até 50 caracteres.")]
        public string Destinatario { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"\d{8}", ErrorMessage = "Formato de CEP inválido. Use apenas 8 dígitos.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(50, ErrorMessage = "O endereço pode conter até 50 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        [StringLength(5, ErrorMessage = "O número pode conter até 5 caracteres.")]
        public string Numero { get; set; }

        [StringLength(30, ErrorMessage = "O complemento pode conter até 30 caracteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(30, ErrorMessage = "O bairro pode conter até 30 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(30, ErrorMessage = "A cidade pode conter até 30 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório.")]
        [StringLength(2, ErrorMessage = "O UF deve ter 2 caracteres.")]
        public string UF { get; set; }

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(50, ErrorMessage = "O e-mail pode conter até 50 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
        [RegularExpression(@"\d{11}|\d{14}", ErrorMessage = "O CPF/CNPJ deve ter 11 ou 14 dígitos.")]
        public string CpfCnpj { get; set; }

        [RegularExpression("10", ErrorMessage = "O Pedido deve ter 11 ou 14 dígitos.")]
        public string Pedido { get; set; }

        [Required(ErrorMessage = "A Nota Fiscal é obrigatória.")]
        [StringLength(20, ErrorMessage = "A nota fiscal pode conter até 20 caracteres.")]
        public string NotaFiscal { get; set; }
    }
}

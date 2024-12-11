using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorMp.Components.Pages
{
    public partial class EnderecoRemetente
    {
        public EnderecoRemetente()
        {

        }
    }

    public class RemetenteModel
    {
        [Required(ErrorMessage = "O nome do remetente é obrigatório.")]
        [StringLength(50, ErrorMessage = "O remetente pode conter até 50 caracteres.")]
        public string Remetente { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(9, ErrorMessage = "O CEP deve ter 9 caracteres, incluindo o hífen.")]
        [RegularExpression(@"\d{8}", ErrorMessage = "Formato de CEP inválido.")]
        public string CEPRementente { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        public string EnderecoRemetente { get; set; } = string.Empty;  // Inicializando com valor padrão

        [Required(ErrorMessage = "O Numero é obrigatório.")]
        public string NumeroRemetente { get; set; } = string.Empty; // Inicializando com valor padrão
        public string ComplementoRemetente { get; set; }
        public string BairroRemetente { get; set; }
        public string CidadeRemetente { get; set; }
        public string UFRemetente { get; set; }
        public string EmailRemetente { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
        [RegularExpression(@"\d{11}|\d{14}", ErrorMessage = "O CPF/CNPJ deve ter 11 ou 14 dígitos.")]
        public string CpfCnpjRemetente { get; set; }

        // Construtor opcional se precisar inicializar outros membros
        public RemetenteModel()
        {
            EnderecoRemetente = string.Empty;  // Inicializando o endereço
        }
    }

}



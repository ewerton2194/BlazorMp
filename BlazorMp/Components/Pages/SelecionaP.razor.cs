using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorMp.Components.Pages
{
    public class ModeloCaixa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double? Altura { get; set; }
        public double? Largura { get; set; }
        public double? Comprimento { get; set; }
    }

    public class TipoEmbalagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }
    }

    public class TipoServico
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public List<string> ListaAdicionais { get; set; }
        public string UrlChancela { get; set; }

        public string PrazoEntrega { get; set; }
    }

    public class FormModel : IValidatableObject
    {
        public int IdCliente { get; set; }
        public int IdDepto { get; set; }

        public string CepRemetente { get; set; }

        public string CepDestinatario { get; set; }
        public int EmbalagemSelecionada { get; set; } = -1;

        [Range(1, 100, ErrorMessage = "A altura deve ser entre 1 e 100 cm.")]
        public double? Altura { get; set; }

        [Range(6, 100, ErrorMessage = "A largura deve ser entre 6 e 100 cm.")]
        public double? Largura { get; set; }

        [Range(11, 100, ErrorMessage = "O comprimento deve ser entre 11 e 100 cm.")]
        public double? Comprimento { get; set; }

        [Range(5, 91, ErrorMessage = "O diâmetro deve ser entre 5 e 91 cm.")]
        public double? Diametro { get; set; }

        [Range(0.01, 32000, ErrorMessage = "O peso deve ser entre 0,01g e 32000g.")]
        public int? Peso { get; set; }

        public bool AvisoRecebimento { get; set; } = false;
        public bool MaoPropria { get; set; } = false;
        public bool ProdutoControlado { get; set; } = false;
        public bool PostaRestante { get; set; } = false;

        [Range(0, double.MaxValue, ErrorMessage = "O valor declarado incorreto.")]
        public decimal? ValorDeclarado { get; set; } = 0;

        public string Observacoes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validação para Peso
            if (EmbalagemSelecionada == 002 || EmbalagemSelecionada == 001 || EmbalagemSelecionada == 003)
            {
                if (Peso == null)
                {
                    yield return new ValidationResult("Peso é obrigatório.", new[] { nameof(Peso) });
                }
            }

            // Validação para Altura
            if (EmbalagemSelecionada == 002)
            {
                if (Altura == null)
                {
                    yield return new ValidationResult("A altura é obrigatória.", new[] { nameof(Altura) });
                }
            }

            // Validação para Largura
            if (EmbalagemSelecionada == 002 || EmbalagemSelecionada == 001)
            {
                if (Largura == null)
                {
                    yield return new ValidationResult("A largura é obrigatória.", new[] { nameof(Largura) });
                }
            }

            // Validação para Comprimento
            if (EmbalagemSelecionada == 002 || EmbalagemSelecionada == 001 || EmbalagemSelecionada == 003)
            {
                if (Comprimento == null)
                {
                    yield return new ValidationResult("O comprimento é obrigatório.", new[] { nameof(Comprimento) });
                }
            }

            // Validação para Diâmetro (Cilindro)
            if (EmbalagemSelecionada == 003)
            {
                if (Diametro == null)
                {
                    yield return new ValidationResult("O diâmetro é obrigatório.", new[] { nameof(Diametro) });
                }
            }
        }
    }

    internal class OrcarPostagem
    {
        public int idCliente { get; set; } //153369
        public int idDepto { get; set; }  //691837
        public string cepOrigem { get; set; }//cep do cliente de origem
        public string cepDestino { get; set; }
        public int peso { get; set; }
        public string tipoEmbalagem { get; set; }
        public string valorAdicional { get; set; }
        public string altura { get; set; }
        public string largura { get; set; }
        public string comprimento { get; set; }
        public string diametro { get; set; }
        public bool avisoRecebimento { get; set; }
        public bool maoPropria { get; set; }
        public bool postaRestante { get; set; }
        public bool produtoControlado { get; set; }
        public string Observacoes { get; set; }

        public OrcarPostagem(PostagemService1 postagem)
        {
            idCliente = 177268;
            idDepto = 753779;
            cepOrigem = postagem.CepRemetente;
            cepDestino = postagem.CepDestinatario;
            peso = postagem.Peso;
            tipoEmbalagem = postagem.TipoEmbalagem.ToString();
            valorAdicional = postagem.ValorDeclarado.ToString();
            altura = postagem.Altura;
            largura = postagem.Largura;
            comprimento = postagem.Comprimento;
            diametro = postagem.Diametro;
            avisoRecebimento = postagem.AvisoRecebimento;
            maoPropria = postagem.MaoPropria;
            postaRestante = false;
            produtoControlado = postagem.ProdutoControlado;
        }
    }

    public partial class SelecionaPostagem
    {
        public SelecionaPostagem()
        {
            // Lógica do construtor (se necessário)
        }

        public List<RetornoOrcamento> Itens { get; set; }
    }

    public class RetornoOrcamento
    {
        [JsonPropertyName("codigo")]
        public string? codigo { get; set; }

        [JsonPropertyName("transp")]
        public string? transp { get; set; }

        [JsonPropertyName("servico")]
        public string? servico { get; set; }

        [JsonPropertyName("prazo")]
        public string? prazo { get; set; }

        [JsonPropertyName("valorAdicionais")]
        public string? valorAdicionais { get; set; }

        [JsonPropertyName("valorDeclarado")]
        public string? valorDeclarado { get; set; }

        [JsonPropertyName("valorTotal")]
        public string? valorTotal { get; set; }

        [JsonPropertyName("entregaDomiciliar")]
        public string entregaDomiciliar { get; set; }

        [JsonPropertyName("entregaSabado")]
        public string entregaSabado { get; set; }

        [JsonPropertyName("observacoes")]
        public string? observacoes { get; set; }
    }
}
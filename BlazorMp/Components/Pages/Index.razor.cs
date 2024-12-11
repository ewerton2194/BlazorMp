using BlazorMp.Components.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class CepService
{
    private readonly HttpClient _httpClient;

    public string Cep { get; set; }
    public EnderecoDTO Endereco { get; set; } // Armazenar o endereço completo

    // Injetar HttpClient através do construtor
    public CepService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        // Adiciona o token de autorização, se necessário (apenas uma vez por HttpClient)
        _httpClient.DefaultRequestHeaders.Add("Authorization",
            "Bearer eyJhbGciOiJSUzI1NiJ9.eyJpYXQiOjE3MzM4NzQ3NzcsImlzcyI6InRva2VuLXNlcnZpY2UiLCJleHAiOjE3MzM5NjExNzcsImp0aSI6IjQwYzA4OTU0LTcyMjctNGEzYS04ODY3LWYxY2NlZjYwNzhmNyIsImFtYmllbnRlIjoiUFJPRFVDQU8iLCJwZmwiOiJQSiIsImlwIjoiNDAuMTEyLjEzOS4xODgsIDE5Mi4xNjguMS4xMzIiLCJjYXQiOiJCejAiLCJjYXJ0YW8tcG9zdGFnZW0iOnsiY29udHJhdG8iOiI5OTEyNDEwMDU1IiwibnVtZXJvIjoiMDA3Mjk5MjMwMSIsImRyIjo3MiwiYXBpcyI6W3siYXBpIjoyN30seyJhcGkiOjM0fSx7ImFwaSI6MzV9LHsiYXBpIjozNn0seyJhcGkiOjQxfSx7ImFwaSI6NzZ9LHsiYXBpIjo3OH0seyJhcGkiOjgwfSx7ImFwaSI6ODN9LHsiYXBpIjo4N30seyJhcGkiOjU2Nn0seyJhcGkiOjU4Nn0seyJhcGkiOjU4N30seyJhcGkiOjYyMX0seyJhcGkiOjYyM31dfSwiaWQiOiJvaGFuYWFkbSIsImNucGoiOiIxMTA0NTIwOTAwMDE5OCJ9.OwE51US8eroU04m2EtakY02rcraIBfQq8c8JynLN9vL0jaTBOgZRl3R6pX0OgBaXGc1SNMN2FFeeb_725k40Zo3PebI8yPbHIMBMannS-9Xwv4tYGdiQLFYTxdoe9vD6lUt-A1BX57OL_dfPdR0ysXAUoQ1cg_1Avac9G0S1-9btaRg_G4kd-T7ajPiMWNFIMmHw_TuLV2EsPOYa6bfXIgMWfHgAOF6G7vOQL9OVliI_cbFKh5o5KcqioUlgZu__r2vpEC_kzk9bGlfyij5h0f5nRuQspqc5GPrERcgQPhveG9EzrSC-mElzjlSSUm93iteFFcOJkNXxVIm9A3_2qw");
    }

    // Método para buscar o endereço pelo CEP
    public async Task<EnderecoDTO> BuscarEnderecoPorCepAsync(string cep)
    {
        // URL da API de consulta de CEP
        string url = $"https://api.correios.com.br/cep/v2/enderecos/{cep}";

        try
        {
            // Faz a requisição GET e retorna o resultado como um objeto CepDTO
            return await _httpClient.GetFromJsonAsync<EnderecoDTO>(url);
        }
        catch (HttpRequestException ex)
        {
            // Tratamento de erros HTTP
            throw new HttpRequestException("Erro ao consumir a API de CEP.", ex);
        }
    }
}

namespace BlazorMp.Components.Pages
{
    public class Cep
    {
        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [StringLength(9, ErrorMessage = "O campo CEP deve ter 9 caracteres, incluindo o hífen.")]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "Formato de CEP inválido. Use o formato 00000-000.")]
        public string CepValue { get; set; }
    }

    public class EnderecoDTO
    {
        public string Cep { get; set; }
        public string Uf { get; set; }
        public int NumeroLocalidade { get; set; }
        public string Localidade { get; set; }
        public string Logradouro { get; set; }
        public string TipoLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string Complemento { get; set; }
        public string Abreviatura { get; set; }
        public string Bairro { get; set; }
        public int TipoCep { get; set; }
        public string CepUnidadeOperacional { get; set; }
        public string Lado { get; set; }
        public int NumeroInicial { get; set; }
        public int NumeroFinal { get; set; }
    }

    public class PostagemService1
    {
        public int IdCliente { get; set; }
        public int IdDepto { get; set; }
        public string CepDestinatario { get; set; }
        public int TipoEmbalagem { get; set; }
        public string Altura { get; set; }
        public string Largura { get; set; }
        public string Comprimento { get; set; }
        public string Diametro { get; set; }
        public int Peso { get; set; }
        public int Cubico { get; set; }
        public string CodigoServico { get; set; }
        public bool AvisoRecebimento { get; set; }

        public bool PostaRestante { get; set; }
        public bool MaoPropria { get; set; }
        public bool ProdutoControlado { get; set; }
        public decimal ValorDeclarado { get; set; }
        public decimal Valor { get; set; }

        public string DescricaoServico { get; set; }

        public string PrazoEntrega { get; set; }
        public string NomeRemetente { get; set; }
        public string CepRemetente { get; set; }
        public string EnderecoRemetente { get; set; }
        public string NumeroRemetente { get; set; }
        public string ComplementoRemetente { get; set; }
        public string BairroRemetente { get; set; }
        public string CidadeRemetente { get; set; }
        public string UfRemetente { get; set; }
        public string EmailRemetente { get; set; }
        public string CpfCnpjRemetente { get; set; }
        public string NomeDestinatario { get; set; }
        public string EnderecoDestinatario { get; set; }
        public string NumeroDestinatario { get; set; }
        public string ComplementoDestinatario { get; set; }
        public string BairroDestinatario { get; set; }
        public string CidadeDestinatario { get; set; }
        public string UfDestinatario { get; set; }
        public string EmailDestinatario { get; set; }
        public string CpfCnpjDestinatario { get; set; }
        public string Pedido { get; set; }
        public string NotaFiscal { get; set; }
        public string EnderecoVizinho { get; set; }

        public string EntregaDomiciliar { get; set; }

        public string EntregaSabado { get; set; }
        public string valorServico { get; set; }

        public string servico { get; set; }
        public string transportadora { get; set; }

        public string Observacoes { get; set; }

        public List<RetornoOrcamento> ItensOrcamento { get; set; }
    }
}
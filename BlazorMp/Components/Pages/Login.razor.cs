using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorMp.Components.Pages
{
    public partial class Login
    {
        //  public Login() { }

        [Inject]
        public HttpClient HttpClient { get; set; }

        public LoginService loginService;

        protected override void OnInitialized()
        {
            //loginModel = new LoginModel();
            loginService = new LoginService(HttpClient);
        }
    }

    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string UserID { get; set; }
        public string AccessKey { get; set; }
        public string Token { get; private set; }

        public async Task<string> GetTokenAsync()
        {
            var response = await _httpClient.PostAsJsonAsync("https://centraldeenviosapi.azurewebsites.net/Login/api/Login", new { userID = UserID, accessKey = AccessKey });

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginService>();
                Token = result?.Token;
                return Token;
            }
            else
            {
                throw new Exception("Erro ao obter o token de acesso.");
            }
        }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        [StringLength(100, ErrorMessage = "O campo E-mail deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(8, ErrorMessage = "O campo Senha deve ter no mínimo 8 caracteres.")]
        [StringLength(100, ErrorMessage = "O campo Senha deve ter no máximo 100 caracteres.")]
        public string Senha { get; set; }
    }

    public class LoginResponse
    {
        public bool authenticated { get; set; }
        public string idFilial { get; set; }
        public string idUsuario { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string accessToken { get; set; }
        public string message { get; set; }
    }
}
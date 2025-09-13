using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_RH
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> PostLoginAsync(FuncionarioLoginModelcs loginData, string apiUrl)
        {
            // Serializar os dados em JSON
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);

            // Crie o conteúdo da requisição com o JSON
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Faça a requisição POST
            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                // Requisição bem-sucedida, retorne a resposta
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                // Trate erros, se necessário, ou retorne uma mensagem de erro
                return "Ocorreu um erro ao fazer login.";
            }
        }
    }
}
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using WebApp.Models;
using WebApp.Services.ApiClient;

namespace WebApp.Controllers
{

    public class ContatosController : Controller
    {
        private HttpClient cliente;

        [HttpGet]
        [Route("/[Controller]")]
        public IActionResult Listar()
        {
            cliente = new HttpClient();

            HttpResponseMessage retorno = cliente.GetAsync(PARAMETROS.MontarUrl("/api/Pessoa")).Result;

            if (retorno.IsSuccessStatusCode)
                return View(retorno.Content != null ? JsonSerializer.Deserialize<List<ContatoModel>>(retorno.Content.ReadAsStringAsync().Result) : new List<ContatoModel>());
            if (retorno.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View(new List<ContatoModel>());
            else
                return BadRequest("erro");

        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View("Contato", new ContatoModel());
        }

        [HttpGet]
        [Route("/[Controller]/Listar/{id}")]
        public IActionResult Listar(int? id = null)
        {
            if(id is null )
                return View("Contato", new ContatoModel());

            cliente = new HttpClient();
            HttpResponseMessage retorno = cliente.GetAsync(PARAMETROS.MontarUrl("/api/Pessoa/" + id)).Result;
            var contato = JsonSerializer.Deserialize<ContatoModel>(retorno.Content.ReadAsStringAsync().Result);

            return View("Contato", contato);
        }
        [HttpPost]
        public IActionResult Salvar(ContatoModel contato)
        {
            var contentString = new StringContent(JsonSerializer.Serialize(contato), Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient cliente = new HttpClient();
            HttpResponseMessage retorno = cliente.PostAsync(PARAMETROS.MontarUrl("/api/Pessoa/"), contentString).Result;
            if (!retorno.IsSuccessStatusCode)
            {
                if (retorno.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    JsonDocument obj = JsonDocument.Parse(retorno.Content.ReadAsStringAsync().Result);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Erros:");

                    foreach (JsonProperty property in obj.RootElement.GetProperty("errors").EnumerateObject())
                    {
                        string fieldName = property.Name;
                        string errorMessage = property.Value[0].GetString();
                        sb.AppendLine($"- {fieldName}: {errorMessage}");
                    }

                    string errorString = sb.ToString();

                    //ModelState.AddModelError("", "Erro ao salvar contato: " + errorString);
                    //return View("Contato", contato.errorMessage = errorString);
                }
            }

            return RedirectToAction("Listar");

        }
        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            cliente = new HttpClient();
            HttpResponseMessage retorno = cliente.DeleteAsync(PARAMETROS.MontarUrl("/api/Pessoa/" + id)).Result;
            //var lista = JsonSerializer.Deserialize<List<ContatoModel>>(retorno.Content.ReadAsStringAsync().Result);

            return Ok();
        }



    }
}
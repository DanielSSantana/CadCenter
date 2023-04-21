using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EnderecosController : Controller
    {
        private HttpClient cliente;
        public IActionResult ListarPorPessoa(long id)
        {
            cliente = new HttpClient();
            var retorno = cliente.GetAsync(PARAMETROS.MontarUrl($"/api/Endereco/GetByPessoa/{id}")).Result;

            if (retorno.IsSuccessStatusCode)
            {
               var list = JsonSerializer.Deserialize<List<EnderecoModel>>(retorno.Content.ReadAsStringAsync().Result);

                return View("Listar", new EnderecosPorPessoa { PessoaId = id, Enderecos = list} );
            }
            if (retorno.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View("Listar", new EnderecosPorPessoa { PessoaId = id, Enderecos = new List<EnderecoModel>() });
            else
                return BadRequest("erro");
        }

        public IActionResult Listar(long id)
        {
            cliente = new HttpClient();
            var retorno = cliente.GetAsync(PARAMETROS.MontarUrl($"/api/Endereco/{id}")).Result;

            if (retorno.StatusCode == HttpStatusCode.OK)
            {
                var endereco = JsonSerializer.Deserialize<EnderecoModel>(retorno.Content.ReadAsStringAsync().Result);
                return View("Endereco", endereco);
            }             
            if (retorno.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View(new EnderecoModel());
            else
                return BadRequest("erro");
        }

        public IActionResult Cadastrar(long pessoaId)
        {
            return View("EnderecoCadastrar", new EnderecoModel { pessoaId = pessoaId });
        }

        public IActionResult Salvar(EnderecoModel endereco)
        {
            var contentString = new StringContent(JsonSerializer.Serialize(endereco), Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient cliente = new HttpClient();
            HttpResponseMessage retorno = cliente.PostAsync(PARAMETROS.MontarUrl("/api/Endereco/"), contentString).Result;

            if(retorno.StatusCode == HttpStatusCode.BadRequest)
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

                // endereco.errorMessage = Jo retorno.Content
                return RedirectToAction("ListarPorPessoa/" + endereco.pessoaId);
            }

            return RedirectToAction("ListarPorPessoa", "Enderecos", new { id = endereco.pessoaId });
        }
        public IActionResult Excluir(int id)
        {
            cliente = new HttpClient();
            HttpResponseMessage retorno = cliente.DeleteAsync(PARAMETROS.MontarUrl("/api/Endereco/" + id)).Result;
            if (retorno.StatusCode == HttpStatusCode.OK)
                return Ok();

            else
            {
                var lista = JsonDocument.Parse(retorno.Content.ReadAsStringAsync().Result);
                return NotFound(lista.RootElement.ToString());
            }

        }

        public IActionResult Ativar(int id)
        {
            var contentString = new StringContent("", Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            cliente = new HttpClient();
            HttpResponseMessage retorno = cliente.PostAsync(PARAMETROS.MontarUrl($"/api/Endereco/{id}/Ativar"), contentString).Result;
            if (retorno.StatusCode == HttpStatusCode.OK)
                return Ok();

            else
            {
                var lista = JsonDocument.Parse(retorno.Content.ReadAsStringAsync().Result);
                return NotFound(lista.RootElement.ToString());
            }
        }

        public IActionResult Inativar(int id)
        {
            var contentString = new StringContent("", Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            cliente = new HttpClient();
            HttpResponseMessage retorno = cliente.PostAsync(PARAMETROS.MontarUrl($"/api/Endereco/{id}/Inativar"), contentString).Result;
            if (retorno.StatusCode == HttpStatusCode.OK)
                return Ok();

            else
            {
                var lista = JsonDocument.Parse(retorno.Content.ReadAsStringAsync().Result);
                return NotFound(lista.RootElement.ToString());
            }
        }


    }
}

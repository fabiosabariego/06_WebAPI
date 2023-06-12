using ApiClient.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;



string endpoint = "https://5cb544bd07f233001424ceb8.mockapi.io/fiap/fornecedor";

HttpClient client = new HttpClient();

var fornecedor = new FornecedorModel();

fornecedor.Name = "Fabio";
fornecedor.Email = "fabio@gmail.com";
fornecedor.Telefone = "55 11 99999-0000";
fornecedor.Website = "fabio.com.br";
fornecedor.Suffix = "INC";
fornecedor.Id = "32";

var conteudoJson = JsonConvert.SerializeObject(fornecedor);
var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

var resposta = await client.PostAsync(endpoint, conteudoJsonString);

Console.WriteLine(conteudoJson.ToString());



/*

var resposta = await client.GetAsync(endpoint);

if (resposta.IsSuccessStatusCode)
{
    var conteudo = await resposta.Content.ReadAsStringAsync();

    var fornecedores = JsonConvert.DeserializeObject<List<FornecedorModel>>(conteudo);

    Console.WriteLine(conteudo.ToString());
}

*/

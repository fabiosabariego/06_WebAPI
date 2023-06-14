using Fiap.Api.AspNet5.Models;
using Fiap.Api.AspNet5.Repository;
using Fiap.Api.AspNet5.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet5.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        // podemos fazer da forma abaixo, ou dentro do metodo usar a propriedade
        // [FromServices] IProdutoRepository produtoRepository  -> tambem ira funcionar

        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        
        [HttpGet]
        [ApiVersion("1.0", Deprecated = true)]
        public ActionResult<IList<ProdutoModel>> Get()
        {
            var lista = produtoRepository.FindAll();

            if (lista.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(lista);
            }
        }
        

        /// <summary>
        ///     Resumo do Metodo GET da API de Produto
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="tamanho"></param>
        /// <returns></returns>

        [HttpGet]
        [ApiVersion("2.0")]
        [ApiVersion("3.0")]
        public ActionResult<dynamic> Get(
            [FromQuery] int pagina = 0,     // Esta forma representa um valor default de 0
            [FromQuery] int tamanho = 3)
        {
            var totalGeral = produtoRepository.Count();
            var totalPaginas = Convert.ToInt16(Math.Ceiling((double) totalGeral / tamanho));

            var anterior = (pagina > 0) ? $"produto?pagina={pagina - 1}&tamanho={tamanho}" : "";
            var proximo = (pagina < (totalPaginas - 1)) ? $"produto?pagina={pagina + 1}&tamanho={tamanho}" : "";

            if (pagina > totalPaginas)
            {
                return NotFound();
            }

            var produtos = produtoRepository.FindAll(pagina, tamanho);

            var retorno = new
            {
                total = totalGeral,
                totalPaginas = totalPaginas,
                anterior = anterior,
                proximo = proximo,
                produtos = produtos
            };

            return Ok(retorno);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProdutoModel> GetById([FromRoute] int id)
        {
            var produto = produtoRepository.FindById(id);

            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(produto);
            }
        }

        [HttpPost]
        public ActionResult<ProdutoModel> InsertData([FromBody] ProdutoModel produtoModel)
        {


            try
            {
                var id = produtoRepository.Insert(produtoModel);
                produtoModel.ProdutoId = id;

                var url = Request.GetEncodedUrl().EndsWith("/") ? Request.GetEncodedUrl() : Request.GetEncodedUrl() + "/";
                var location = new Uri(url + id);

                return Created(location, produtoModel);

            }
            catch (Exception ex)
            {
                return BadRequest(new {message = $"Nao foi possivel cadastrar o Produto {ex.Message}"});
            }

        }

        [HttpDelete("{id:int}")]
        public ActionResult<ProdutoModel> Delete([FromRoute] int id)
        {

            produtoRepository.Delete(id);
            return NoContent();

        }


        [HttpPut("{id:int}")]
        public ActionResult<ProdutoModel> Put([FromRoute] int id, [FromBody] ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtoModel.ProdutoId)
            {
                return NotFound();
            }


            try
            {
                produtoRepository.Update(produtoModel);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = $"Nao foi possivel alterar a categoria {id}" });
            }


        }

    }
}

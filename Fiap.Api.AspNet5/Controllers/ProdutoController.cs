using Fiap.Api.AspNet5.Models;
using Fiap.Api.AspNet5.Repository;
using Fiap.Api.AspNet5.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        [HttpGet]
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
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

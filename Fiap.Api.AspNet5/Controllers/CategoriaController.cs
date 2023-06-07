using Fiap.Api.AspNet5.Models;
using Fiap.Api.AspNet5.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public ActionResult<IList<CategoriaModel>> Get()
        {
            var lista = categoriaRepository.FindAll();

            if (lista.Count == 0)
            {
                return NoContent();
            }

            return Ok(lista);
        }


        [HttpGet("{id:int}")]
        public ActionResult<CategoriaModel> Get([FromRoute] int id)
        {
            var categoria = categoriaRepository.FindById(id);

            if (categoria == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categoria);
            }


        }

        [HttpPost]
        public ActionResult<CategoriaModel> Post([FromBody] CategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var id = categoriaRepository.Insert(categoriaModel);
                categoriaModel.CategoriaId = id;

                var url = Request.GetEncodedUrl().EndsWith("/") ? Request.GetEncodedUrl() : Request.GetEncodedUrl() + "/";
                var location = new Uri(url + id);

                return Created(location, categoriaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Nao foi possivel cadastrar a categoria {ex.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaModel> Delete([FromRoute] int id)
        {

            categoriaRepository.Delete(id);
            return NoContent();

        }


        [HttpPut("{id:int}")]
        public ActionResult<CategoriaModel> Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaModel.CategoriaId)
            {
                return NotFound();
            }


            try
            {
                categoriaRepository.Update(categoriaModel);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = $"Nao foi possivel alterar a categoria {id}" });
            }


        }

    }
}

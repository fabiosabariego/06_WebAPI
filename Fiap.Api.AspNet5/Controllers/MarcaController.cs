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
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }


        [HttpGet]
        public ActionResult<IList<MarcaModel>> GetAll()
        {
            var listaMarcas = marcaRepository.FindAll();

            if (listaMarcas.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listaMarcas);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<MarcaModel> GetId([FromRoute] int id)
        {
            var marca = marcaRepository.FindById(id);

            if (marca == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(marca);
            }
        }
        
        [HttpPost]
        public ActionResult<MarcaModel> PostInsert([FromBody] MarcaModel marcaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var id = marcaRepository.Insert(marcaModel);
                marcaModel.MarcaId = id;

                var url = Request.GetEncodedUrl().EndsWith("/") ? Request.GetEncodedUrl() : Request.GetEncodedUrl() + "/";
                var location = new Uri(url + id);

                return Created(location, marcaModel);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Nao foi possivel cadastrar a marca!! - {ex.Message}" });
            }
        }

        
        [HttpPut("{id:int}")]
        public ActionResult<MarcaModel> PutUpdate([FromBody] MarcaModel marcaModel, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marcaModel.MarcaId)
            {
                return NotFound();
            }

            try
            {
                marcaRepository.Update(marcaModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Nao foi possivel alterar a marca {id}" });
            }
        }

        
        [HttpDelete("{id:int}")]
        public ActionResult<MarcaModel> Delete([FromRoute] int id)
        {
            marcaRepository.Delete(id);
            return NoContent();
        }

    }
}

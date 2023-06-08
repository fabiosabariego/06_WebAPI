using Fiap.Api.AspNet5.Models;
using Fiap.Api.AspNet5.Repository;
using Fiap.Api.AspNet5.Repository.Interface;
using Fiap.Api.AspNet5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }


        [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Login([FromBody] UsuarioModel usuarioModel)
        {

            var usuario = usuarioRepository.FindByName(usuarioModel.NomeUsuario);

            if (usuario == null)
            {
                return NotFound();
            }
            else if (! usuario.Senha.Equals(usuarioModel.Senha))
            {
                return NotFound();
            }
            else
            {
                usuario.Senha = "";

                var token = AuthenticationService.GetToken(usuario);

                var retorno = new
                {
                    token = token,
                    usuario = usuario
                };

                return Ok(retorno);
            }

        }

    }
}

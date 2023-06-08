using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.AspNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AcessoTestController : ControllerBase
    {
        [HttpGet]
        [Route("Anonimo")]
        [AllowAnonymous]
        public string Anonimo()
        {
            return "Anonimo";
        }

        [HttpGet]
        [Route("Autenticado")]
        public string Autenticado()
        {
            return "Autenticado";
        }

        [HttpGet]
        [Route("Junior")]
        [Authorize("Senior, Pleno, Junior")]
        public string Junior()
        {
            return "Junior";
        }


        [HttpGet]
        [Route("Pleno")]
        [Authorize("Senior, Pleno")]
        public string Pleno()
        {
            return "Pleno";
        }

        [HttpGet]
        [Route("Senior")]
        [Authorize(Roles = "Senior")]
        public string Senior()
        {
            return "Senior";
        }
    }
}

using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {
        public LoginController () {

        }

        [HttpPost]
        public async Task<object> Login ([FromBody] UserEntity userEntity, [FromServices] ILoginService service) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            if (userEntity == null) {
                return BadRequest ();
            }

            try {
                var result = await service.FindByLogin (userEntity);
                if (result != null) {
                    return result;
                } else {
                    return NotFound ();
                }
            } catch (ArgumentException e) {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}

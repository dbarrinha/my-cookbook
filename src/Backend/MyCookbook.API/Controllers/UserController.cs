using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Communication.Requests;
using MyCookbook.Communication.Responses;

namespace MyCookbook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson),StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            var response = new ResponseRegisterUserJson
            {
                Name = request.Name + " foi criado"
            };

            return Created(string.Empty, response);
        }
    }
}

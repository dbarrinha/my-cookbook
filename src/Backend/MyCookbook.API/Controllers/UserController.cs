using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCookbook.Application.UseCases.User.Register;
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
            RegisterUserUseCase useCase = new();
            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}

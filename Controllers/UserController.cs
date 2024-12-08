using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Interfaces;
using ProjetDotNet.Models.Entities;

namespace ProjetDotNet.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var listUsers = _service.GetUsers();
            if (listUsers != null)
            {
                return new OkObjectResult(listUsers);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] User add)
        {
            _service.AddUser(add);
            return new OkObjectResult("");
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateUser(User update)
        {
            _service.UpdateUser(update);
            return new OkObjectResult("");
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUser(User delete)
        {
            _service.DeleteUser(delete);
            return new OkObjectResult("");
        }
    }
}

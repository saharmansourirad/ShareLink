using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Data.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersService _usersService;

        public UsersController( UsersService usersServic)
        {
            _usersService = usersServic;
        }

        [HttpPost("add-user")]
        public IActionResult AddUser([FromBody] UserVM user)
        {
            _usersService.AddUser(user);
            return Ok();
        }

        [HttpGet("get-all-user")]
        public IActionResult GetAllUsers()
        {
            var allUsers = _usersService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("get-user-by-id/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _usersService.GetUserById(id);
            return Ok();
        }

        [HttpPut("update-user-by-id/{id}")]

        public IActionResult UpdateUserById(int id, [FromBody] UserVM user)
        {
            var updatedUser = _usersService.UpdateUserById(id, user);

            return Ok(updatedUser);
        }


        [HttpDelete("delete-user-by-id/{id}")]

        public IActionResult DeletePostById(int id)
        {
            _usersService.DeleteUserById(id);

            return Ok();
        }


    }
}

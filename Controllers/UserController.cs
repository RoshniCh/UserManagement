using Microsoft.AspNetCore.Mvc;
using UserManagement.Repositories;
using UserManagement.Models.Request;
using UserManagement.Models.Database;
using System;

namespace UserManagement.Controllers {

    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase {
        private readonly IUserRepo _users;
        public UserController(IUserRepo users)
        {
            _users = users;
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest newUser) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userCreated = _users.Create(newUser);
            if (userCreated == null)
            {
                return StatusCode(401);
            }
            else
            {
                return StatusCode(200);
            }
        }

        [HttpGet("read/{id}")]
        public user ReadUser([FromRoute] int id) {
            var userInfo = _users.Read(id);
            return userInfo;
        }

        [HttpPost("update")]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest updateUser) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userInfo = _users.Read(updateUser.id);
            if (userInfo == null)
            {
                return StatusCode(204);
            }
            userInfo.email = updateUser.email;
            userInfo.givenName = updateUser.givenName;
            userInfo.familyName = updateUser.familyName;

            var updatedUser = _users.Update(userInfo);

            if (updatedUser == null)
            {
                return StatusCode(401);
            }
            else
            {
                return StatusCode(200);
            }
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteUser ([FromRoute] int id) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userInfo = _users.Read(id);
            if (userInfo == null)
            {
                return StatusCode(204);
            }
            var deletedUser = _users.Delete(userInfo);
            if (deletedUser == null)
            {
                return StatusCode(401);
            }
            else
            {
                return StatusCode(200);
            }
        }
    }
}
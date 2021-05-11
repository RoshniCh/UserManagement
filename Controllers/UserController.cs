using Microsoft.AspNetCore.Mvc;
using UserManagement.Repositories;
using UserManagement.Models.Request;
using UserManagement.Models.Database;
using System.Text.RegularExpressions;
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

            bool isValidEmail = _users.ValidateEmail(newUser.email);
            if (!isValidEmail){
                return StatusCode(400, "Invalid email");
            }

            var userCreated = _users.Create(newUser);
            
            if (userCreated == null)
            {
                return StatusCode(401);
            }
            else
            {
                return StatusCode(200, "User Id created is " + userCreated.id);
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

            bool isValidEmail = _users.ValidateEmail(updateUser.email);
            if (!isValidEmail){
                return StatusCode(400, "Invalid email");
            }
            
            var userInfo = _users.Read(updateUser.id);
            if (userInfo == null)
            {
                return StatusCode(400, "User does not exist");
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

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser ([FromRoute] int id) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userInfo = _users.Read(id);
            if (userInfo == null)
            {
                return StatusCode(400, "User does not exist");
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
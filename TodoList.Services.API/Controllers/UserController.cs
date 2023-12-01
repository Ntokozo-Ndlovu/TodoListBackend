using Microsoft.AspNetCore.Mvc;
using TodoList.API.DataToObject;
using TodoList.API.Requests;
using TodoList.API.Responses;
using TodoList.Data.Entities;
using TodoList.Data.Repository;
using TodoList.Domain.JwtAuthorization;

namespace TodoList.Services.API.Controllers
{
    [ApiController]
    [Route("api/v2/user")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepositoryService;
        private IJwtAuthorization jwtAuthorizationService;
        public UserController(IUserRepository userRepositoryService, IJwtAuthorization jwtAuthization)
        {
            this.jwtAuthorizationService = jwtAuthization;
            this.userRepositoryService = userRepositoryService;
        }


         [HttpGet("")]
        public ActionResult<UserResponse<UserDataToObject>> getUser([FromHeader] string authorization)
        {

            string token = authorization.Split(" ")[1];
            string userIdString = this.jwtAuthorizationService.DecodeJwtToken(token);
            var user = this.userRepositoryService.findUserById(Guid.Parse(userIdString));

            if(user == null)
                return NotFound();
            UserResponse<UserDataToObject> response = new UserResponse<UserDataToObject>()
            {
                user = user.asUserDTO(),
            };
            return response;
        }


        [HttpPatch("")]
        public ActionResult<UserResponse<UserDataToObject>> updateUser([FromHeader] string authorization,[FromBody] UpdateUserRequest userBody)
        {
            string token = authorization.Split(" ")[1];
            string userIdString = this.jwtAuthorizationService.DecodeJwtToken(token);
            var user = this.userRepositoryService.findUserById(Guid.Parse(userIdString));

             if(user == null)
            { 
                return NotFound(); 
            }
             
             if(userBody.name != null)
                user.Name = userBody.name;
             
            if(userBody.email != null)
                user.Email = userBody.email;
             
            if(userBody.surname != null)   
                user.Surname = userBody.surname;

            this.userRepositoryService.updateUser(user);
            UserResponse<UserDataToObject> response = new UserResponse<UserDataToObject>()
            {
                user = user.asUserDTO()
            };
            return response;
        }
    }
}

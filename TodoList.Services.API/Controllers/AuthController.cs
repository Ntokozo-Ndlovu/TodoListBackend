using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TodoList.API.Requests;
using TodoList.API.Responses;
using TodoList.Data.Entities;
using TodoList.Data.Repository;
using TodoList.Domain.JwtAuthorization;

namespace TodoList.Services.API.Controllers
{
    [ApiController]
    [Route("/api/v2/auth")]
    public class AuthController : ControllerBase
    {

     
        private IUserRepository userRepositoryService;
        private IJwtAuthorization jwtAuthorizationService;
        public AuthController(IUserRepository userRepository, IJwtAuthorization authorizationService)
        {
            this.jwtAuthorizationService = authorizationService;
            this.userRepositoryService = userRepository;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody]LoginRequest body)
        {
           UserEntity user = this.userRepositoryService.findUserByEmail(body.email);
            if (user == null)
                return NotFound();

            return new LoginResponse()
            {
                userId = user.Id,
                token = jwtAuthorizationService.GenerateJwtToken(user.Id)
            };
        }

        [HttpPost("register")]
        public ActionResult<RegisterResponse> Register([FromBody] RegisterRequest body)
        {
            UserEntity user = new UserEntity()
            {
                name = body.name,
                email = body.email,
                password = body.password,
                surname = body.surname,
                Id = Guid.NewGuid(),

            };
            this.userRepositoryService.createUser(user);

            return new RegisterResponse()
            {
                userId = user.Id,
                token = jwtAuthorizationService.GenerateJwtToken(user.Id)
            };
        }

    }
}

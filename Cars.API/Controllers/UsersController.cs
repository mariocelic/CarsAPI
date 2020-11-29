using AuthenticationPlugin;
using Cars.DAL;
using Cars.DAL.Entities;
using Cars.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cars.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly AuthService _auth;

        public UsersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _auth = new AuthService(_configuration);
        }

        [HttpPost]
        public async Task<IActionResult> Register ([FromBody] UserEntity user)
        {
            var userWithSameEmail = await _context.Users.Where(u => u.Email == user.Email).SingleOrDefaultAsync();

            if (userWithSameEmail != null)
            {
                return BadRequest("User with same email already exists!");
            }

            var userObj = new UserEntity
            {
                Email = user.Email,
                Password = SecurePasswordHasherHelper.Hash(user.Password),
                Role = "Users"
            };

            _context.Users.Add(userObj);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login ([FromBody] UserEntity user)
        {
            var userEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if(userEmail == null)
            {
                return NotFound();
            }

            if (!SecurePasswordHasherHelper.Verify(user.Password, userEmail.Password))
            {
                return Unauthorized();
            }

            var claims = new[]
             {
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.Role, userEmail.Role)
             };

            var token = _auth.GenerateAccessToken(claims);

            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = userEmail.UserId
            });






        }
    }
}

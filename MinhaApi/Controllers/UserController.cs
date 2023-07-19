using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductsAPI.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsAPI.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Api Ok :: Accessed at :: " + DateTime.Now;
        }

        [HttpPost("register")]
        public async Task<ActionResult> UserRegister(UserDTO model)
        {
            try
            {
                if (model == null) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var role = new IdentityRole
                {
                    Name = "User"
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                var resultRole = await _roleManager.CreateAsync(role);

                await _userManager.AddToRoleAsync(user, "User");

                if (!result.Succeeded) return BadRequest(result.Errors);
                if (!resultRole.Succeeded) return BadRequest(role);

                await _signInManager.SignInAsync(user, false);
                return Ok(model);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request.");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> UserLogin(UserDTO userInfo)
        {
            if (userInfo == null) return BadRequest("Invalid request data...");

            var result = await _signInManager.PasswordSignInAsync(userInfo.UserName,
                userInfo.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded) return Ok(GenerateToken(userInfo));
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login...");
                return BadRequest();
            }
        }

        private UserTokenDTO GenerateToken(UserDTO userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var hoursExpiration = _config["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(hoursExpiration));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["TokenConfiguration:Issuer"],
                audience: _config["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new UserTokenDTO()
            {
                Authenticated = true,
                UserToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Successfully generated Jwt token..."
            };
        }
    }
}

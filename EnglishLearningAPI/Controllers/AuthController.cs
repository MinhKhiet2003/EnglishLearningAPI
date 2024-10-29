using EnglishLearningAPI.Dtos.Requests;
using EnglishLearningAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EnglishLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.AuthenticateUserAsync(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized("Thông tin đăng nhập không chính xác.");
            }

            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            // Lưu Refresh Token vào CSDL
            user.refresh_token = refreshToken;
            user.refresh_token_expiry = DateTime.Now.AddDays(7);
            await _userService.UpdateUserAsync(user);

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [Authorize]
        [HttpGet("user-info")]
        public IActionResult GetUserInfo()
        {
            // Lấy thông tin từ Claims trong token
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userId == null)
            {
                return Unauthorized("Token không hợp lệ.");
            }

            // Trả về thông tin người dùng
            return Ok(new
            {
                UserId = userId,
                Email = email,
                Role = role
            });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRefreshRequest request)
        {
            var user = await _userService.GetUserByRefreshTokenAsync(request.RefreshToken);
            if (user == null || user.refresh_token_expiry < DateTime.Now)
            {
                return Unauthorized("Refresh Token không hợp lệ hoặc đã hết hạn.");
            }

            var newAccessToken = GenerateAccessToken(user);
            var newRefreshToken = GenerateRefreshToken();

            // Cập nhật Refresh Token mới trong CSDL
            user.refresh_token = newRefreshToken;
            user.refresh_token_expiry = DateTime.Now.AddDays(7);
            await _userService.UpdateUserAsync(user);

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        private string GenerateAccessToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()), 
                new Claim(ClaimTypes.Email, user.email),                       
                new Claim(ClaimTypes.Role, user.role)                          
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

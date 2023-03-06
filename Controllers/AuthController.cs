using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MultiBackend.Dtos;
using MultiBackend.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MultiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private DataContext _context;
        private IConfiguration _configuration;
        public AuthController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Customer>> Register(UserRegisterDto user)
        {
            Customer customer = new Customer();

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            customer.Name = user.Name;
            customer.Email = user.Email;
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;
            customer.Address = user.Address;
            customer.CardInformation = user.CardInformation;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserLoginDto>> Login(UserLoginDto user)
        {
            Customer customer = GetUser(user.Email);

            if(customer == null)
            {
                BadRequest("there is no registed user with this email" + user.Email);
            }

            if(!VerifyPasswordHash(user.Password, customer.PasswordHash, customer.PasswordSalt))
            {
                return BadRequest("Wrong credentials");
            }

            string token = CreateToken(user);
            user.Token = token;
            return Ok(user);
        }

        private string CreateToken(UserLoginDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("mysecrettoken"));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt )
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }

        }

        private Customer GetUser(string email)
        {
            var user = _context.Customers.Where(c => c.Email == email).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

    }
}

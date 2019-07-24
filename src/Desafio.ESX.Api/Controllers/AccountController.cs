using ApplicationCore.ESX.ViewModels.Account;
using Infrastructure.ESX.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.ESX.Api.Controllers
{
    public class AccountController : BaseApiV1Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public AccountController(IConfiguration config, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadResponse(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

            if (!result.Succeeded)
                return Unauthorized();


            var appUser = await _userManager.FindByEmailAsync(model.Email);


            return Response(new
            {
                token = GenerateJWToken(appUser),
                data = model
            });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadResponse("Dados Inválidos");
            }

            var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadResponse(user);
            }

            return Response(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]string id)
        {
            if (!ModelState.IsValid)
            {
                return BadResponse("Dados Inválidos");
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadResponse("Usuário não encontrado");
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadResponse("Não foi possivel deletar o usuário");
            }

            return Response("Deletado com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadResponse("Dados Inválidos");
            }

            var users = await _userManager.Users.ToListAsync();

            return Response(users);
        }


        private string GenerateJWToken(ApplicationUser user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Id, JwtRegisteredClaimNames.NameId),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email.ToString())
                }
            );

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
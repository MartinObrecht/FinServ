//using FinServ.Domain.Entities.Admin;
//using FinServ.Domain.Entities.Helpers;
//using FinServ.Domain.Interfaces;
//using FinServ.Domain.Repositories;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.BearerToken;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Net;
//using System.Security.Claims;

//namespace FinServ.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        private readonly IAdminRepository _adminRepository;

//        public LoginController(IAdminRepository adminRepository)
//        {
//            _adminRepository = adminRepository;
//        }

//        [HttpPost]
//        public IResult Login([FromBody] Admin request)
//        {
//            if (_adminRepository.Autorization(request.Email, request.CodigoAcesso))
//            {
//                var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Email, request.Email)
//                };

//                var claimsIdentity = new ClaimsIdentity(claims, BearerTokenDefaults.AuthenticationScheme);
//                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


//                return Results.SignIn(claimsPrincipal);
//            }
//            else
//            {
//                return Results.Unauthorized();
//            }
//        }
//    }
//}

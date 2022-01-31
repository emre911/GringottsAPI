﻿using Gringotts.Data;
using Gringotts.Data.Repositories;
using GringottsAPI.Business;
using GringottsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GringottsAPI.Controllers
{
    [ApiController]
    [Route("api/Token/[action]")]
    public class TokenController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public TokenController(IUserRepository userRepository, IJwtAuthenticationManager jwtAuthenticationManager, ILogger<TokenController> logger, IConfiguration configuration, IGringottsDataContext gringottsDataContext) : base(logger, configuration, gringottsDataContext)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get bearer token with Username and Password of User
        /// </summary>
        /// <param name="GetTokenInputModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] GetTokenInputModel input)
        {
            var token = await new AuthenticateManager(_userRepository, _jwtAuthenticationManager).AuthenticateAsync(input.UserName, input.Password);

            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}

﻿using ExchangeOffice.Application.DTO;
using ExchangeOffice.Application.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeOffice.API.Controllers {
	[Route("api/user")]
	[ApiController]
	public class AuthController : ControllerBase {
		private readonly IUserManager _manager;
		public AuthController(IUserManager manager) {
			_manager = manager;
		}

		[HttpPost("login")]
		public async Task<string> Login(string login, string password) {
			return await _manager.LoginAsync(login, password);
		}

		[HttpPost("register")]
		public async Task Register(InsertUserDto data) {
			await _manager.RegisterAsync(data);
		}

		[HttpPut("changerole")]
		public async Task ChangeRole(string login, Guid roleId) {
			await _manager.ChangeUserRoleAsync(login, roleId);
		}

		[HttpDelete("deactivate")]
		public async Task DeactivateUser(string login) {
			await _manager.DeactivateUserAsync(login);
		}
	}
}

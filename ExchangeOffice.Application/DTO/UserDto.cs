using ExchangeOffice.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExchangeOffice.Application.DTO {
	public class UserDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public string Login { get; set; }
		public string PasswordHash { get; set; }
		public UserRoleDto? Role { get; set; }
		public ContactDto? Contact { get; set; }
		public bool IsActive { get; set; }
	}

	public class InsertUserDto {
		public string Login { get; set; }
		[JsonPropertyName("password")]
		public string PasswordHash { get; set; }
		public Guid? RoleId { get; set; } = null;
		public Guid? ContactId { get; set; } = null;
	}

	public class AuthUserDto {
		public UserDto User { get; set; }
		public string Token {
			get; set;
		}
	}
}

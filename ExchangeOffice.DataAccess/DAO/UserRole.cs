using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.DataAccess.DAO {
	public class UserRole {
		public Guid Id { get; set; }
		public Guid CreatedOn { get; set; }
		public string Name { get; set; }
	}
}

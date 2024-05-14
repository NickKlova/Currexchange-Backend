using ExchangeOffice.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Application.DTO {
	public class FundDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public CurrencyDto? Currency { get; set; }
		public decimal Amount { get; set; }
		public bool IsActive { get; set; }
	}

	public class InsertFundDto {
		public Guid CurrencyId { get; set; }
		public decimal Amount { get; set; }
	}
}

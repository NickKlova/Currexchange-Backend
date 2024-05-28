using ExchangeOffice.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Application.DTO {
	public class IssuanceLogDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public Guid CurrencyId { get; set; }
		public CurrencyDto Currency { get; set; }
		public decimal BuyRate { get; set; }
		public decimal SellRate { get; set; }
	}
	public class InsertIssuanceLogDto {
		public Guid CurrencyId { get; set; }
		public decimal BuyRate { get; set; }
		public decimal SellRate { get; set; }
	}
}

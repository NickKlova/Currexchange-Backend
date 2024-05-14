using ExchangeOffice.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Application.DTO {
	public class TransactionDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public ContactDto? Contact { get; set; }
		public RateDto? Rate { get; set; }
		public bool IsSale { get; set; }
		public decimal Amount { get; set; }
	}

	public class InsertTransactionDto {
		public Guid ContactId { get; set; }
		public Guid RateId { get; set; }
		public bool IsSale { get; set; }
		public decimal Amount { get; set; }
	}
}

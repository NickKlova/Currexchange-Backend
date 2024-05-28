using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeOffice.Application.DTO {
	public class TransactionTypeDto {
		public Guid Id { get; set; }
		public DateTime CreatedOn { get; set; }
		public string Name { get; set; }
	}
}

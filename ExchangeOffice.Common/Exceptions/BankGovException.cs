using ExchangeOffice.Common.Exceptions.Abstractions;

namespace ExchangeOffice.Common.Exceptions {
	public class BankGovException : BaseCommonException {
		public BankGovException(int statusCode, string layer, string message) : base(statusCode, layer, message) {
		}
	}
}

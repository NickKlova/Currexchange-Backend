using ExchangeOffice.Common.Exceptions.Abstractions;

namespace ExchangeOffice.Common.Exceptions {
	public class RecordNotFoundException : BaseCommonException {
		public RecordNotFoundException(int statusCode, string layer, string message) : base(statusCode, layer, message) {
		}
	}
}

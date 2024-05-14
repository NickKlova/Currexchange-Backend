using ExchangeOffice.Common.Exceptions.Abstractions;

namespace ExchangeOffice.Common.Exceptions {
	public class ActionNotPerformedException : BaseCommonException {
		public ActionNotPerformedException(int statusCode, string layer, string message) : base(statusCode, layer, message) {
		}
	}
}

namespace ExchangeOffice.Common.Exceptions.Abstractions {
	public abstract class BaseCommonException : Exception {
		public int StatusCode { get; set; }
		public string Layer { get; set; }
		public BaseCommonException(int statusCode, string layer, string message) : base(message) {
			StatusCode = statusCode;
			Layer = layer;
		}
	}
}

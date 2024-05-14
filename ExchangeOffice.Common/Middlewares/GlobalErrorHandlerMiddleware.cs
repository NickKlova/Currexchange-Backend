using ExchangeOffice.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ExchangeOffice.Common.Middlewares {
	public class GlobalErrorHandlerMiddleware {
		private readonly RequestDelegate _next;
		public GlobalErrorHandlerMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context) {
			try {
				await _next(context);
			} catch (Exception ex) {
				await HandleExceptionAsync(context, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception) {
			context.Response.ContentType = "application/json";
			switch (exception) {
				case ActionNotPerformedException actionNotPerformedException:
				context.Response.StatusCode = actionNotPerformedException.StatusCode;

				var errorObject = new {
					IsSuccess = false,
					Layer = actionNotPerformedException.Layer,
					Message = actionNotPerformedException.Message,
					StatusCode = actionNotPerformedException.StatusCode
				};

				await context.Response.WriteAsync(JsonSerializer.Serialize(errorObject));
				break;

				case RecordNotFoundException notFoundException:
				context.Response.StatusCode = notFoundException.StatusCode;

				errorObject = new {
					IsSuccess = false,
					Layer = notFoundException.Layer,
					Message = notFoundException.Message,
					StatusCode = notFoundException.StatusCode
				};

				await context.Response.WriteAsync(JsonSerializer.Serialize(errorObject));
				break;

				default:
				context.Response.StatusCode = 500;

				errorObject = new {
					IsSuccess = false,
					Layer = "Global",
					Message = exception.Message,
					StatusCode = 500
				};

				await context.Response.WriteAsync(JsonSerializer.Serialize(errorObject));
				break;
			}
		}
	}
}

using System.Net;

namespace Turkuaz_WebAPI.Extensions.Exceptions.ExceptiHandler
{

	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlerMiddleware> _logger;

		public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}
		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var innerExMessage = GetInnermostExceptionMessage(exception);

			_logger.LogError(exception, $"{exception.Source} || {innerExMessage}");

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			return Task.CompletedTask;
		}

		private string GetInnermostExceptionMessage(Exception exception)
		{
			if (exception.InnerException != null)
				return GetInnermostExceptionMessage(exception.InnerException);

			return exception.Message;
		}
	}
}

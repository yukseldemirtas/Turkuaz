namespace Turkuaz_WebAPI.Extensions.Exceptions.ExceptiHandler
{
	public static class ExceptionHandlerMiddlewareExtensions
	{
		public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
		{
			return app.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}
}

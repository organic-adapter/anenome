using Microsoft.AspNetCore.Mvc.Formatters;

namespace Anenome.WebAPI.InputFormatters
{
	public class PlainTextInputFormatter : InputFormatter
	{
		private const string ContentType = "text/plain";

		public PlainTextInputFormatter()
		{
			SupportedMediaTypes.Add(ContentType);
		}

		public override bool CanRead(InputFormatterContext context)
		{
			var contentType = context.HttpContext.Request.ContentType ?? string.Empty;
			return contentType.StartsWith(ContentType);
		}

		public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
		{
			var request = context.HttpContext.Request;
			using (var reader = new StreamReader(request.Body))
			{
				var content = await reader.ReadToEndAsync();
				return await InputFormatterResult.SuccessAsync(content);
			}
		}
	}
}
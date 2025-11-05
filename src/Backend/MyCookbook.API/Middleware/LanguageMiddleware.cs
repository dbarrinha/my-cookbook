using System.Globalization;

namespace MyCookbook.API.Middleware
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestedLanguage = context.Request.Headers.AcceptLanguage.FirstOrDefault();
            
            var cultureInfo = new CultureInfo("es");
            
            if (!string.IsNullOrWhiteSpace(requestedLanguage))
            {
                var firstLanguage = requestedLanguage.Split(',').FirstOrDefault();
                var languageCode = firstLanguage?.Split(';').FirstOrDefault()?.Trim();
                
                if (!string.IsNullOrWhiteSpace(languageCode))
                {
                    try
                    {
                        cultureInfo = new CultureInfo(languageCode);
                    }
                    catch (CultureNotFoundException)
                    {
                        cultureInfo = new CultureInfo("en");
                    }
                }
            }
            
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}

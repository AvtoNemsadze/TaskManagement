using Microsoft.AspNetCore.Http;

namespace TaskManagement.Application.Translation
{
    public class LanguageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetAcceptedLanguage()
        {
            var acceptLanguageHeader = _httpContextAccessor?.HttpContext?.Request.Headers["Accept-Language"].ToString();

            string cultureCode = "ka-GE"; // default language

            if (!string.IsNullOrWhiteSpace(acceptLanguageHeader))
            {
                var userLanguages = acceptLanguageHeader.Split(',');

                foreach (var lang in userLanguages)
                {
                    var langParts = lang.Trim().Split(';');

                    var langCode = langParts[0];
                    if (langCode == "en-US" || langCode == "ka-GE")
                    {
                        cultureCode = langCode;
                        break;
                    }
                }
            }

            return cultureCode;
        }
    }
}

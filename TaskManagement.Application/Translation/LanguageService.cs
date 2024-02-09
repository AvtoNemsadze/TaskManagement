using AutoMapper;
using Microsoft.AspNetCore.Http;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Translation
{
    public class LanguageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public LanguageService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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


        public async Task<int> GetLanguageId()
        {
            var languagePrefix = GetAcceptedLanguage();

            var languageId = await _unitOfWork.LanguageRepository.GetLanguageIdByPrefixAsync(languagePrefix);

            return languageId;
        }
    }
}

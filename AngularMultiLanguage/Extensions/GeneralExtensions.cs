using AngularMultiLanguage.Constants;

namespace AngularMultiLanguage.Extensions
{
    public static class GeneralExtensions
    {

        public static string GetRequestedLanguage(
            this HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.TryGetValue(AppConstants.LANGHEADER,
                out var extractedLang))
                return "en";

            var lang = extractedLang.ToString().Split(',').FirstOrDefault();
            var allowed = new[] { "en","ar","en-US","ar-BH","en-us","ar-bh" };
            return string.IsNullOrEmpty(lang)?
                "en":
                allowed.FirstOrDefault(x=>x==extractedLang)==null?
                "en":lang.Substring(0,2);

        }
    }
}

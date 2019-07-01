using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture 
        /// </summary>
        /// <param name="language">The language whose corresponding culture will be set</param>
        /// <returns>A string value representing a culture. This value defaults to "en" 
        /// if an invalid argument is passed.</returns>
        // JON KARLSEN: 
        // Implemented the method
        public string SetCulture(string language)
        {
            // Default to English/en if language arg is null
            if (language == null)
            {
                return "en";
            }

            string culture;

            // Default culture is "en", french is "fr" and spanish is "es".
            if (language == "French") 
                    culture = "fr";
            else if (language == "Spanish")
                    culture = "es";
            else culture = "en";

            return culture;
        }

        /// <summary>
        /// Update the culture cookie
        /// </summary>
        public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
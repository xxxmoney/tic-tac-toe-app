using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.FormUI.Enums;

namespace TicTacToe.FormUI.Helpers
{
    /// <summary>
    /// Switcher for forms' language.
    /// </summary>
    public interface ILanguageSwitcher
    {
        /// <summary>
        /// Sets current language by language enum.
        /// </summary>
        /// <param name="language"></param>
        void SetCurrentLanguage(LanguageEnum language);
    }

    public class LanguageSwitcher : ILanguageSwitcher
    {
        private static void SetLanguage(string languageCode)
        {
            var culture = new System.Globalization.CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public void SetCurrentLanguage(LanguageEnum language)
        {
            switch (language)
            {
                case LanguageEnum.EN:
                    SetLanguage("en");
                    break;
                case LanguageEnum.CZ:
                    SetLanguage("cs");
                    break;
                default:
                    break;
            }
        }
    }
}

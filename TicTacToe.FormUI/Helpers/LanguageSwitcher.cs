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
        LanguageEnum GetCurrentLanguage();
        void SetCurrentLanguage(LanguageEnum language);
    }

    public class LanguageSwitcher : ILanguageSwitcher
    {
        public LanguageEnum GetCurrentLanguage()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentLanguage(LanguageEnum language)
        {
            throw new NotImplementedException();
        }
    }
}

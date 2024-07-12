using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Code.Localization.UseCases
{
    public class LocaleChanger
    {
        public void ChangeLocale(Locale locale)
        {
            LocalizationSettings.Instance.SetSelectedLocale(locale);
        }
    }
}
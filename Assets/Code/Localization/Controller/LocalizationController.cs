using System;
using System.Collections.Generic;
using Code.Localization.UseCases;
using Code.SaveSystem.UseCases;
using UnityEngine.Localization;

namespace Code.Localization.Controller
{
    public class LocalizationController : ISavableComponent
    {
        private LocaleChanger localeChanger;

        private int selectedLocaleIndex;

        public List<Locale> locales;

        public void SetLocale(int indexLocales)
        {
            if(indexLocales > locales.Count)
                return;
            selectedLocaleIndex = indexLocales;
            localeChanger.ChangeLocale( locales[selectedLocaleIndex]);
        }

        public Dictionary<string, object> CaptureComponentState()
        {
            var state = new Dictionary<string, object>();
            state.Add("selectedLocaleIndex", selectedLocaleIndex);
            return state;
        }

        public void RestoreState(Dictionary<string, object> state)
        {
            var savedSelectLocaleIndex = (int) state.GetValueOrDefault("selectedLocaleIndex", 0);
            SetLocale(savedSelectLocaleIndex);
        }
    }
    
}

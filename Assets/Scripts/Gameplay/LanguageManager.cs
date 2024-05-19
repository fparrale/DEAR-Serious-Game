using System.Collections;
using System.Collections.Generic;
using SaveSystem;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

namespace Gameplay
{
    public class LanguageManager : MonoBehaviour, ISavableComponent
    {

        public Locale englishLocale;
        public Locale spanishLocale;

        private int lenguageIndex;

        [Required]
        public TMP_Dropdown LanguageDropdown;

        private void Start() {
            LanguageDropdown.value = lenguageIndex;
        }

        public void ChangeLanguage(int localeInt)
        {
            SetLocale(localeInt);

            lenguageIndex = localeInt;
        }

        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
        
            state.Add("languageIndex", lenguageIndex);

            return state;
        }

        public void RestoreState(object state)
        {
            var restoredState = (Dictionary<string, object>) state;
            lenguageIndex = (int) restoredState.GetValueOrDefault("languageIndex", 0);
            LanguageDropdown.value = lenguageIndex;
            SetLocale(lenguageIndex);

        }

        private void SetLocale(int localeInt)
        {
            if(localeInt == 0 )
                LocalizationSettings.Instance.SetSelectedLocale(englishLocale);

            if(localeInt == 1 )
                LocalizationSettings.Instance.SetSelectedLocale(spanishLocale);
        }
    }

}

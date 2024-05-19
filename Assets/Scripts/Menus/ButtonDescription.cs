using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using TMPro;


namespace Menus
{
    public class ButtonDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public LocalizedString localizedString;

        public TMP_Text TMP_Text_description;

        public void OnPointerEnter(PointerEventData eventData)
        {
            TMP_Text_description.SetText(localizedString.GetLocalizedString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TMP_Text_description.SetText("");
        }
    }

}

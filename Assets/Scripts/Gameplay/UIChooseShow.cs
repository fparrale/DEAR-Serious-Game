using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UIElements;

namespace Gameplay
{
    public class UIChooseShow : MonoBehaviour
    {
        public LocalizedString correct;
        public LocalizedString incorrect;

        public Animation animationComponent;

        public Color correctColor;
        public Color incorrectColor;

        public TMP_Text text;

        public void PlayAnimation(bool isCorrect)
        {
            if(isCorrect)
            {
                text.SetText(correct.GetLocalizedString());
                text.color = correctColor;
            }
            else
            {
                text.SetText(incorrect.GetLocalizedString());
                text.color = incorrectColor;
            }
            // var posStart = transform.position;
            // posStart.y = -70;
            // transform.position = posStart;
            animationComponent.Stop();
            animationComponent.Play(PlayMode.StopAll);
        }

        
    }    
}

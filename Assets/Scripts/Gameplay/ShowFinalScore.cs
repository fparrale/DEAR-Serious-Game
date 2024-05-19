using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ShowFinalScore : MonoBehaviour
    {
        public GameManager gameManager;

        public TMP_Text corrects;
        public TMP_Text incorrects;

        private void Awake() {
            corrects.SetText(gameManager.corrects.ToString());
            incorrects.SetText(gameManager.incorrects.ToString());
        }
    }    
}


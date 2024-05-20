using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class PointsUI : MonoBehaviour
    {
        public GameManager gameManager;

        public TMP_Text correctTmp;
        public TMP_Text incorrectTmp;


        private void Update() {
            correctTmp.SetText(gameManager.corrects.ToString());
            incorrectTmp.SetText(gameManager.incorrects.ToString());
        }
              
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class SpriteChanger : MonoBehaviour
    {
        public List<Sprite> sprite;

        public Image imageComponent;

        private void Awake() {
            if(imageComponent == null)
                imageComponent = GetComponent<Image>();
        } 

        public void ChangeSprite(int index)  {
            imageComponent.sprite = sprite[index];
        }


    }
}

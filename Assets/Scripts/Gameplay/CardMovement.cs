using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.PropertyVariants.TrackedProperties;

namespace Gameplay
{
    public class CardMovement : MonoBehaviour, IPointerDownHandler
    {
        public bool canDrag = false;

        [SerializeField]
        private float rotationWhenDragging;
        [SerializeField]
        private float distanceWhenDragging;

        [SerializeField]
        private float timeToReturnPosition;

        [SerializeField]
        private Color colorWhenSelect;

        [SerializeField]
        private TMP_Text ambiguousText;
        [SerializeField]
        private TMP_Text noAmbiguousText;

        public Action<float> onStopDragging;

        public AudioSource audioSource;
        private bool hasPlayedSound = false;

        #region internal calculations
        private bool clickedInCard;

        private Vector3 initialPosition;
        private Vector3 initialRotation;

        private Vector3 initialLocalPosition;
        private Vector3 initialLocalRotation;
        
        private Vector3 positionWhenStopDragging;
        private Vector3 rotationWhenStopDragging;

        private float timeReturing;
        #endregion

        private void Start() {
            //StartCoroutine(PrintMouse());
            initialPosition = transform.position;
            initialRotation = transform.rotation.eulerAngles;

            initialLocalPosition = transform.localPosition;
            initialLocalRotation = transform.localRotation.eulerAngles;
        }

        private void Update() 
        {
            if(canDrag == false) return;

            MoveCard();
        }

        private void MoveCard()
        {
            //When stop dragging
            if(Input.GetMouseButtonUp(0) && clickedInCard == true)
            {
                clickedInCard = false;

                positionWhenStopDragging = transform.localPosition;
                rotationWhenStopDragging = transform.localRotation.eulerAngles;

                if(rotationWhenStopDragging.z > 90)
                {
                    rotationWhenStopDragging.z -= 360;
                }
                
                timeReturing = 0;

                onStopDragging?.Invoke(Input.mousePosition.x);
                return;
            }

            //while is not dragging
            if(clickedInCard == false){
                //return to originalPosition 

                transform.localPosition = Vector3.Lerp(positionWhenStopDragging, initialLocalPosition, timeReturing);
                transform.eulerAngles = Vector3.Lerp(rotationWhenStopDragging, initialLocalRotation, timeReturing);

                timeReturing += Time.deltaTime * timeToReturnPosition;
                
                ambiguousText.color   = Color.white;
                noAmbiguousText.color = Color.white;
                
                return;
            }

            //When is dragging

            float screenSize = (float) Screen.width;

            float ambigousZone   = screenSize  * (1f/3f);
            float noAmbigousZone = screenSize * (2f/3f);
            float middleScreen   = screenSize / 2;

            var relativeMousePosition = Input.mousePosition.x - middleScreen;
            Vector3 positionToGo = initialPosition;
            Vector3 rotationToGo = initialRotation;

            //Going left
            if(relativeMousePosition < 0)
            {
                var relativePercentageToMiddleScreen = relativeMousePosition / (-middleScreen);

                positionToGo.x -= distanceWhenDragging;
                rotationToGo.z -= rotationWhenDragging;

                transform.position = Vector3.Lerp(initialPosition, positionToGo, relativePercentageToMiddleScreen);
                transform.eulerAngles = Vector3.Lerp(initialRotation, rotationToGo, relativePercentageToMiddleScreen);
            }

            //Going Right
            if(relativeMousePosition > 0)
            {
                var relativePercentageToMiddleScreen = relativeMousePosition / middleScreen;

                positionToGo.x += distanceWhenDragging;
                rotationToGo.z += rotationWhenDragging;

                transform.position = Vector3.Lerp(initialPosition, positionToGo, relativePercentageToMiddleScreen);
                transform.eulerAngles = Vector3.Lerp(initialRotation, rotationToGo, relativePercentageToMiddleScreen);
            }

            if(Input.mousePosition.x < ambigousZone)
            {
                ambiguousText.color   = colorWhenSelect;
                noAmbiguousText.color = Color.white;
                if(hasPlayedSound == false)
                {
                    audioSource.Play();
                    hasPlayedSound = true;
                }
            }
            else if(Input.mousePosition.x > noAmbigousZone)
            {
                noAmbiguousText.color  = colorWhenSelect;
                ambiguousText.color    = Color.white;
                if(hasPlayedSound == false)
                {
                    audioSource.Play();
                    hasPlayedSound = true;
                }
            }
            else
            {
                ambiguousText.color   = Color.white;
                noAmbiguousText.color = Color.white;
                hasPlayedSound = false;
            }

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            clickedInCard = true;
        }

        public IEnumerator PrintMouse()
        {
            while(true)
            {
                var middleScreen   = Screen.width / 2;
                var relativeMousePosition = Input.mousePosition.x - middleScreen;
                
                Debug.Log($"Middle Screen {middleScreen}");
                Debug.Log($"relativeMousePosition {relativeMousePosition}");
                yield return new WaitForSeconds(1f);
            }
        }
    }
    
}


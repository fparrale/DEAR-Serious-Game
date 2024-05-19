using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Data;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class Card : MonoBehaviour
    {
        public TMP_Text text;
        CardMovement cardMovement;

        public Requirement requirement;

        public Action CorrectAction;
        public Action IncorrectAction;

        private void Start() {
            cardMovement = GetComponent<CardMovement>();
            cardMovement.onStopDragging += Choose;
        }

        public void Choose(float mousePosition)
        {
            float screenSize = (float) Screen.width;

            float ambigousZone   = screenSize  * (1f/3f);
            float noAmbigousZone = screenSize * (2f/3f);

            if(Input.mousePosition.x < ambigousZone)
            {
                //Correct
                if(requirement.requirementType == RequirementType.ambiguous)
                {
                    CorrectAction?.Invoke();
                }else{ //Incorrect
                    IncorrectAction?.Invoke();
                }
            }
            else if(Input.mousePosition.x > noAmbigousZone)
            {
                if(requirement.requirementType == RequirementType.noAmbiguous)
                {
                    CorrectAction?.Invoke();
                }else{ //Incorrect
                    IncorrectAction?.Invoke();
                }
            }
        }

        public void SetRequirement(Requirement requirementToSet)
        {
            if(requirementToSet == null)
            {
                requirement = null;
                text.SetText("");
                cardMovement.canDrag = false;
            }

            requirement = requirementToSet;
            text.SetText(requirement.description);
        }

    }
    
}

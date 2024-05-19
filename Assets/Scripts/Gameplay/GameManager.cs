using System.Collections.Generic;
using Gameplay.Data;
using Gameplay.States;
using TMPro;
using UnityEngine;
using Utils.Audio;
using Utils.StatePattern;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameManager : StateMachine<GameManager>
    {
        public RequirementProvider requirementProvider;

        public List<Requirement> requirements;

        public TMP_Text textCurrentRequirement;

        public GameObject startPanel;
        public GameObject endPanel;
        
        public Image timerImage;

        public int currentRequirementIndex = 0;

        public Card card;

        public AudioController audioController;

        public UIChooseShow uiChooseShow;

        [HideInInspector]
        public int corrects;
        public int incorrects;

        private void Start() 
        {
            currentState = new StartState(this);
            currentState.OnEnterState();
            requirementProvider = FindAnyObjectByType<RequirementProvider>();
            requirements = requirementProvider.GetRequirements();
        }

        private void Update() {
            currentState.OnUpdateState();
            textCurrentRequirement.SetText($"{currentRequirementIndex}/{requirements.Count}");
        }



    }
    
}


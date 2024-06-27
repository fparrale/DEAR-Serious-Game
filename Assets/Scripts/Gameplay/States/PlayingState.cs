using Gameplay.Data;
using UnityEngine;
using Utils.StatePattern;


namespace Gameplay.States
{
    public class PlayingState : State<GameManager>
    {
        public PlayingState(GameManager context) : base(context){}

        public float time;

        public float maxTime;

        public override void OnEnterState()
        {
            context.card.CorrectAction += ChooseCorrect;
            context.card.IncorrectAction += ChooseIncorrect;

            SetNextRequirement();
        }

        public override void OnExitState()
        {
            context.currentState = new EndState(context);
            context.currentState.OnEnterState();
        }

        public override void OnUpdateState()
        {
            //Control the timer
            
        }

        public void ChooseCorrect()
        {
            context.corrects += 1;
            context.audioController.Play("correct");
            context.uiChooseShow.PlayAnimation(true);
            SetNextRequirement();
        }

        public void ChooseIncorrect()
        {
            context.incorrects += 1;
            context.audioController.Play("incorrect");
            context.uiChooseShow.PlayAnimation(false);
            context.ShowHelpUI();
            SetNextRequirement();
        }

        public void SetNextRequirement()
        {
            if(context.currentRequirementIndex >= context.requirements.Count)
            {
                OnExitState();
                return;
            }

            context.card.SetRequirement(context.requirements[context.currentRequirementIndex]);
            
            context.currentRequirementIndex++;
        }

        private void CalculateTimeByWordsAmount()
        {
            int amountWords = context.card.requirement.description.Split(' ').Length;

            maxTime = Mathf.Clamp(amountWords / 2 , 4, Mathf.Infinity);
            time = maxTime;
        }


    }
}
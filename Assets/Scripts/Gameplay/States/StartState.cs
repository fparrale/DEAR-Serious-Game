using UnityEngine;
using Utils.StatePattern;


namespace Gameplay.States
{
    public class StartState : State<GameManager>
    {
        public StartState(GameManager context) : base(context){
            this.context =   context;
        }

        public override void OnEnterState()
        {
            //Set all data in the context
            context.startPanel.SetActive(true);
        }

        public override void OnUpdateState()
        {
            if(Input.GetMouseButtonDown(0))
            {
                OnExitState();
            }
        }

        public override void OnExitState()
        {
            context.startPanel.SetActive(false);
            context.currentState = new PlayingState( (GameManager) context);
            context.currentState.OnEnterState();
        }

        
    }
}
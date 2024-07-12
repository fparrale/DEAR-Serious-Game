using Code.Game.Controller;
using Utilities.Pattern.StateMachine;

namespace Code.Game.States
{
    public class WaitingForStartGameState : State<GameStateMachine>
    {
        public WaitingForStartGameState(GameStateMachine context) : base(context)
        {
        }

        public override void OnEnterState()
        {
        }

        public override void OnExitState()
        {   
        }

        public override void OnUpdateState()
        {   
        }
    }
}
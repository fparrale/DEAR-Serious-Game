using Utils.StatePattern;


namespace Gameplay.States
{
    public class EndState : State<GameManager>
    {
        public EndState(GameManager context) : base(context){}

        public override void OnEnterState()
        {
            context.card.GetComponent<CardMovement>().canDrag = false;
            context.endPanel.SetActive(true);
        }

        public override void OnExitState()
        {
            
        }

        public override void OnUpdateState()
        {
            
        }
    }
}
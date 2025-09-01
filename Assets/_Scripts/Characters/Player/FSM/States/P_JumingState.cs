using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States
{
    [CreateAssetMenu(fileName = "JumpingState", menuName = "FSM/States/JumpingState")]
    public class P_JumingState : P_BaseState
    {
        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            MovementFSM fsm = controller as MovementFSM;
            if (fsm.isGrounded)
            {
                fsm.PlayerVelocity.y = Mathf.Sqrt(fsm.Character.JumpHeight * -2f * fsm.Character.Gravity);
            }
        }

        public override void Execute(MonoBehaviour controller)
        {
            base.Execute(controller);
            MovementFSM fsm = controller as MovementFSM;

            if (fsm.isGrounded && fsm.PlayerVelocity.y < 0)
            {
                fsm.TransitionToState(fsm.config.IdleState);
            }
        }
    }
}
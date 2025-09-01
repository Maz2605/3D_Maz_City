using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "FSM/States/IdleState")]
    public class P_IdleState : P_BaseState
    {
        public override void Execute(MonoBehaviour controller)
        {
            MovementFSM fsm = controller as MovementFSM;
            
            // fsm.Animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
            
            if (InputContext.Jump.Pressed && fsm.isGrounded)
            {
                fsm.TransitionToState(fsm.config.JumpState);
            }
            else
            {
                float horizontal = InputContext.Move.x;
                float vertical = InputContext.Move.y;
                Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
                
                if (move != Vector3.zero && InputContext.Sprint.Pressed)
                {
                    fsm.TransitionToState(fsm.config.RunState);
                }
                else if (move != Vector3.zero)
                {
                    fsm.TransitionToState(fsm.config.WalkState);
                }
            }
        }
    }
}
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States
{
    [CreateAssetMenu(fileName = "RuningState", menuName = "FSM/States/RuningState")]
    public class P_RuningState : P_BaseState
    {
        public override void Execute(MonoBehaviour controller)
        {
            base.Execute(controller);
            MovementFSM fsm = controller as MovementFSM;
            
            if(!fsm.isGrounded) return;
            
            float horizontal = InputContext.Move.x;
            float vertical = InputContext.Move.y;
            Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
            
            fsm.Controller.Move(move * fsm.Character.RunSpeed * Time.deltaTime);
            
            if (move != Vector3.zero) fsm.transform.forward = move;
            
            // fsm.Animator.SetFloat("moveSpeed", move.magnitude);
            
            if(InputContext.Jump.Pressed && fsm.isGrounded)
            {
                fsm.TransitionToState(fsm.config.JumpState);
            }
            else if (move == Vector3.zero)
            {
                fsm.TransitionToState(fsm.config.IdleState);
            }
            else if (!InputContext.Sprint.Pressed)
            {
                fsm.TransitionToState(fsm.config.WalkState);
            }
        }
    }
}
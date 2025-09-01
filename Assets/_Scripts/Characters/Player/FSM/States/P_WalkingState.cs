using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States
{
    [CreateAssetMenu(fileName = "WalkingState", menuName = "FSM/States/WalkingState")]
    public class P_WalkingState : P_BaseState
    {
        public override void Execute(MonoBehaviour controller)
        {
            MovementFSM fsm = controller as MovementFSM;
            
            float horizontal = InputContext.Move.x;
            float vertical = InputContext.Move.y;
            
            Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
        
            fsm.Controller.Move(move * fsm.Character.WalkSpeed * Time.deltaTime);

            if (move != Vector3.zero) fsm.transform.forward = move;
        
            // fsm.Animator.SetFloat("moveSpeed", move.magnitude);

            if (InputContext.Jump.Pressed && fsm.isGrounded)
            {
                fsm.TransitionToState(fsm.config.JumpState);
            }
            else if (InputContext.Sprint.Pressed && move != Vector3.zero)
            {
                fsm.TransitionToState(fsm.config.RunState);
            }
            else if (move == Vector3.zero)
            {
                fsm.TransitionToState(fsm.config.IdleState);
            }
        } 
    }
}
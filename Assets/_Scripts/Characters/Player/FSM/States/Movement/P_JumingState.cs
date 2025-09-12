using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States.Movement
{
    [CreateAssetMenu(fileName = "JumpingState", menuName = "FSM/States/JumpingState")]
    public class P_JumingState : BaseState
    {
        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            // (controller as MovementFSM).Animator.SetInteger("Jump");
        }

        public override void Execute(MonoBehaviour controller)
        {
            MovementFSM movementFsm = controller as MovementFSM;

            float airControlSpeed = movementFsm.Character.WalkSpeed * 0.8f;
            Vector3 move = new Vector3(movementFsm.CurrentMoveInput.x, 0, movementFsm.CurrentMoveInput.y);
            movementFsm.Controller.Move(move * airControlSpeed * Time.deltaTime);

            if (movementFsm.isGrounded && movementFsm.PlayerVelocity.y < 0)
            {
                movementFsm.TransitionToState(movementFsm.config.idleState);
            }
        }

        public override void OnExit(MonoBehaviour controller)
        {
            base.OnExit(controller);
        }
    }
}
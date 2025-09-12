using _Scripts.DesignPattern.StateMachine;
using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States.Movement
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "FSM/States/IdleState")]
    public class P_IdleState : BaseState
    {
        private MovementFSM _movementFSM;

        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            _movementFSM = controller as MovementFSM;
            
            EventManager.Instance.Subscribe<JumpInputEvent>(HandleJump);
            //Anim
        }

        public override void Execute(MonoBehaviour controller)
        {
            if (_movementFSM.CurrentMoveInput != Vector2.zero)
            {
                _movementFSM.TransitionToState(_movementFSM.config.walkState);
            }
        }

        public override void OnExit(MonoBehaviour controller)
        {
            base.OnExit(controller);
            EventManager.Instance.Unsubscribe<JumpInputEvent>(HandleJump);
        }
        

        private void HandleJump(JumpInputEvent evt)
        {
            if(evt.Phase == InputActionPhase.Started && _movementFSM.isGrounded)
                _movementFSM.TransitionToState(_movementFSM.config.chargingJumpState);
        }
    }
}
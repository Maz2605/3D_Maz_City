using _Scripts.DesignPattern.StateMachine;
using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States.Movement
{
    [CreateAssetMenu(fileName = "WalkingState", menuName = "FSM/States/WalkingState")]
    public class P_WalkingState : BaseState
    {
        private MovementFSM _movementFSM;
        private Vector2 _currentMoveInput;

        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            _movementFSM = controller as MovementFSM;
            
            EventManager.Instance.Subscribe<JumpInputEvent>(HandleJump);
            EventManager.Instance.Subscribe<SprintInputEvent>(HandleSprint);
        }

        public override void Execute(MonoBehaviour controller)
        {
            Vector2 moveInput = _movementFSM.CurrentMoveInput;

            if (moveInput == Vector2.zero)
            {
                _movementFSM.TransitionToState(_movementFSM.config.idleState);
                return;
            }
            
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized;
            _movementFSM.Controller.Move(move * _movementFSM.Character.WalkSpeed * Time.deltaTime);
            
            if(move != Vector3.zero) _movementFSM.transform.forward = move;
            
            //Anim
        }

        public override void OnExit(MonoBehaviour controller)
        {
            base.OnExit(controller);
            EventManager.Instance.Unsubscribe<JumpInputEvent>(HandleJump);
            EventManager.Instance.Unsubscribe<SprintInputEvent>(HandleSprint);
        }
        
        private void HandleSprint(SprintInputEvent evt)
        {
            Debug.Log($"<color=magenta>2. WalkingState received SPRINT event: {evt.IsSprinting}</color>");
            if(evt.IsSprinting && _movementFSM.CurrentMoveInput != Vector2.zero)
                _movementFSM.TransitionToState(_movementFSM.config.runState);
        }

        private void HandleJump(JumpInputEvent evt)
        {
            if(evt.Phase == InputActionPhase.Started && _movementFSM.isGrounded)
                _movementFSM.TransitionToState(_movementFSM.config.chargingJumpState);
        }
        
    }
}
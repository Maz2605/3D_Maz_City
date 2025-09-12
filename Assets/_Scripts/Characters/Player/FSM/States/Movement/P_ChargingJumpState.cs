using _Scripts.DesignPattern.StateMachine;
using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Characters.Player.FSM.States.Movement
{
    [CreateAssetMenu(fileName = "ChanrgingJumpState", menuName = "FSM/States/ChanrgingJumpState")]
    public class P_ChargingJumpState : BaseState
    {
        [SerializeField] private float minChargeTime = 0.1f; 
        [SerializeField] private float maxChargeTime = 3f;
        
        private float _chargeTime;
        private MovementFSM _movementFsm;

        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            _movementFsm = controller as MovementFSM;
            _chargeTime = 0f;
            EventManager.Instance.Subscribe<JumpInputEvent>(HandleJump);
        }

        public override void Execute(MonoBehaviour controller)
        {
            _chargeTime += Time.deltaTime;
        }

        public override void OnExit(MonoBehaviour controller)
        {
            base.OnExit(controller);
            EventManager.Instance.Unsubscribe<JumpInputEvent>(HandleJump);
        }

        private void HandleJump(JumpInputEvent evt)
        {
            if (evt.Phase == InputActionPhase.Canceled)
            {
                float finalCharge = Mathf.Clamp(_chargeTime, minChargeTime, maxChargeTime);
                float jumpForceRatio = Mathf.InverseLerp(minChargeTime, maxChargeTime, finalCharge);
                float finalJumpForce = Mathf.Lerp(_movementFsm.Character.JumpHeight, _movementFsm.Character.JumpHeight * 2f, jumpForceRatio);
                
                Vector3 horizontalVelocity = new Vector3(_movementFsm.CurrentMoveInput.x, 0f, _movementFsm.CurrentMoveInput.y).normalized * _movementFsm.Character.WalkSpeed;
            
                _movementFsm.PlayerVelocity.x = horizontalVelocity.x;
                _movementFsm.PlayerVelocity.z = horizontalVelocity.z;

                _movementFsm.PlayerVelocity.y = Mathf.Sqrt(finalJumpForce * -2f * _movementFsm.Character.Gravity);
                
                _movementFsm.TransitionToState(_movementFsm.config.jumpState);
            }
        }
    }
}
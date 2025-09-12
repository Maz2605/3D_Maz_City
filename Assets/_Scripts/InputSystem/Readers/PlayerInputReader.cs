using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;
using UnityEngine.InputSystem;
using InputActionPhase = _Scripts.InputSystem.Events.InputActionPhase;

namespace _Scripts.InputSystem.Readers
{
    [CreateAssetMenu(fileName = "PlayerInputReader", menuName = "InputSystem/Readers/PlayerInputReader")]
    public class PlayerInputReader : InputReader, InputActionControls.IPlayerActions
    {
        private Vector2 _previousMoveInput; 
        protected override void OnEnable()
        {
            base.OnEnable();
            InputControls?.Player.SetCallbacks(this);
        }

        public override void EnableActions()
        {
            base.EnableActions();
            InputControls?.Player.Enable();
        }

        public override void DisableActions()
        {
            base.DisableActions();
            InputControls?.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 newVal = context.ReadValue<Vector2>();
            if(newVal == _previousMoveInput) return;

            _previousMoveInput = newVal;
            EventManager.EventManager.Instance.Publish(new MoveInputEvent()
            {
                Direction = newVal
            });
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new LookInputEvent()
            {
                Direction = context.ReadValue<Vector2>()
            });
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                EventManager.EventManager.Instance.Publish(new JumpInputEvent()
                {
                    Phase = InputActionPhase.Started
                });
            }
            else if (context.canceled)
            {
                EventManager.EventManager.Instance.Publish(new JumpInputEvent()
                {
                    Phase = InputActionPhase.Canceled
                });
            }
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new SprintInputEvent()
            {
                IsSprinting = context.ReadValueAsButton()
            });
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new CrouchInputEvent());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                EventManager.EventManager.Instance.Publish(new InteractInputEvent());
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new AttackInputEvent()
            {
                IsAttacking = context.ReadValueAsButton()
            });
        }

        public void OnSecondaryAttack(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new SecondaryAttackInputEvent()
            {
                IsAttacking = context.ReadValueAsButton()
            });
        }

        public void OnSwitchWeapon(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new SwitchWeaponInputEvent()
            {
                SwitchValue = context.ReadValue<float>()
            });
        }

        public void OnFreeLook(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new FreeLookInputEvent()
            {
                IsFreeLook = context.ReadValueAsButton()
            });
        }

        public void OnInventory(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new InventoryInputEvent());
        }

        public void OnUseItem(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new UseItemInputEvent());
        }

        public void OnSwitchCamera(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new SwitchCameraInputEvent()
            {
                SwitchValue = context.ReadValue<float>()
            });
        }

        public void OnReload(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new ReloadInputEvent());
        }
    }
}
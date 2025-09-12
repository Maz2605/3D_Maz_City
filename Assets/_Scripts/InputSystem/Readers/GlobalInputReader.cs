using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.InputSystem.Readers
{
    [CreateAssetMenu ( fileName = "GlobalInputReader", menuName = "InputSystem/Readers/GlobalInputReader")]
    public class GlobalInputReader : InputReader, InputActionControls.IGlobalActions
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            InputControls?.Global.SetCallbacks(this);
        }

        public override void EnableActions()
        {
            base.EnableActions ();
            InputControls.Global.Enable();
        }

        public override void DisableActions()
        {
            base.DisableActions();
            InputControls.Global.Disable();
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new PauseInputEvent());
        }

        public void OnOpenMap(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new OpenMapInputEvent());
        }

        public void OnOpenPhone(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new OpenPhoneInputEvent());
        }

        public void OnQuickSave(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new QuickSaveInputEvent());
        }

        public void OnQuickLoad(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new QuickLoadInputEvent());
        }
    }
}

using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.InputSystem.Readers
{
    [CreateAssetMenu(fileName = "VehicleInputReader", menuName = "InputSystem/Readers/VehicleInputReader")]
    public class VehicleInputReader : InputReader, InputActionControls.IVehicleActions
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            InputControls?.Vehicle.SetCallbacks(this);
        }

        public override void EnableActions()
        {
            base.EnableActions();
            InputControls.Vehicle.Enable();
        }

        public override void DisableActions()
        {
            base.DisableActions();
            InputControls?.Vehicle.Disable();
        }

        public void OnSteering(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new SteeringInputEvent()
            {
                Steering = context.ReadValue<float>()
            });
        }

        public void OnThrottle(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new ThrottleInputEvent()
            {
                Throttle = context.ReadValue<float>()
            });
        }

        public void OnBrake(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new BrakeInputEvent()
            {
                Brake = context.ReadValue<float>()
            });
        }

        public void OnHandbrake(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new HandBrakeInputEvent()
            {
                IsBrake = context.ReadValueAsButton()
            });
        }

        public void OnVehicleLook(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new VehicleLookInputEvent()
            {
                Direction = context.ReadValue<Vector2>()
            });
        }

        public void OnFreeLook(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new VehicleFreeLookInputEvent()
            {
                IsFreeLook = context.ReadValueAsButton()
            });
        }

        public void OnExitVehicle(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new ExitVehicleInputEvent());
        }

        public void OnSwitchSeat(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new SwitchSeatInputEvent());
        }

        public void OnHorn(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new HornInputEvent());   
        }

        public void OnLightsToggle(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new LightningInputEvent());
        }

        public void OnVehicleWeaponFire(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new VehicleWeaponInputEvent());
        }

        public void OnSwitchCamera(InputAction.CallbackContext context)
        {
            EventManager.EventManager.Instance.Publish(new SwitchCameraInputEvent());
        }
    }
}

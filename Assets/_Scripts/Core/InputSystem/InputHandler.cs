using System;
using UnityEngine;

namespace _Scripts.Core.InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private InputContext input;
        private InputActionControls _inputActionsControls;

        private void Start()
        {
            _inputActionsControls = InputRouter.Instance.InputActionControls;
        }

        private void Update()
        {
            UpdateGlobalInputs();
            var currentMap = InputRouter.Instance.CurrentInputMap;
            if (currentMap == null) return;
            switch (currentMap.name)
            {
                case "Player":
                    UpdatePlayerInputs();
                    break;
                case "Vehicle":
                    UpdateVehicleInputs();
                    break;
                case "UI":
                    UpdateUIInputs();
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateGlobalInputs()
        {
            input.Pause.UpdateState(_inputActionsControls.Global.Pause);
            input.OpenMap.UpdateState(_inputActionsControls.Global.OpenMap);
            input.OpenPhone.UpdateState(_inputActionsControls.Global.OpenPhone);
            input.QuickSave.UpdateState(_inputActionsControls.Global.QuickSave);
            input.QuickLoad.UpdateState(_inputActionsControls.Global.QuickLoad);
        }

        private void UpdatePlayerInputs()
        {
            input.Move = _inputActionsControls.Player.Move.ReadValue<Vector2>();
            input.Look = _inputActionsControls.Player.Look.ReadValue<Vector2>();
            input.Jump.UpdateState(_inputActionsControls.Player.Jump);
            input.Sprint.UpdateState(_inputActionsControls.Player.Sprint);
            input.Crouch.UpdateState(_inputActionsControls.Player.Crouch);
            input.Interact.UpdateState(_inputActionsControls.Player.Interact);
            input.Attack.UpdateState(_inputActionsControls.Player.Attack);
            input.SecondaryAttack.UpdateState(_inputActionsControls.Player.SecondaryAttack);
            input.Reload.UpdateState(_inputActionsControls.Player.Reload);
            input.Inventory.UpdateState(_inputActionsControls.Player.Inventory);
            input.UseItem.UpdateState(_inputActionsControls.Player.UseItem);
            input.FreeLook.UpdateState(_inputActionsControls.Player.FreeLook);
            
            var switchWeaponValue = _inputActionsControls.Player.SwitchWeapon.ReadValue<float>();
            input.SwitchWeapon = switchWeaponValue > 0 ? 1 : switchWeaponValue < 0 ? -1 : 0;
        }
        private void UpdateVehicleInputs()
        {
            input.Steering = _inputActionsControls.Vehicle.Steering.ReadValue<float>();
            input.Throttle = _inputActionsControls.Vehicle.Throttle.ReadValue<float>();
            input.Brake = _inputActionsControls.Vehicle.Brake.ReadValue<float>();
            input.Handbrake.UpdateState(_inputActionsControls.Vehicle.Handbrake);
            input.ExitVehicle.UpdateState(_inputActionsControls.Vehicle.ExitVehicle);
            input.SwitchSeat.UpdateState(_inputActionsControls.Vehicle.SwitchSeat);
            input.Horn.UpdateState(_inputActionsControls.Vehicle.Horn);
            input.LightsToggle.UpdateState(_inputActionsControls.Vehicle.LightsToggle);
            input.VehicleWeaponFire.UpdateState(_inputActionsControls.Vehicle.VehicleWeaponFire);
            input.SwitchCamera.UpdateState(_inputActionsControls.Vehicle.SwitchCamera);
            input.VehicleLook = _inputActionsControls.Vehicle.VehicleLook.ReadValue<Vector2>();
        }

        private void UpdateUIInputs()
        {
            input.Navigate = _inputActionsControls.UI.Navigate.ReadValue<Vector2>();
            input.Confirm.UpdateState(_inputActionsControls.UI.Confirm);
            input.Cancel.UpdateState(_inputActionsControls.UI.Cancel);
            input.Point = _inputActionsControls.UI.Point.ReadValue<Vector2>();
            input.ScrollWheel = _inputActionsControls.UI.ScrollWheel.ReadValue<Vector2>();
        }
    }
}
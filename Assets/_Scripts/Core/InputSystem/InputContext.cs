using UnityEngine;

namespace _Scripts.Core.InputSystem
{
    [CreateAssetMenu(fileName = "InputContext", menuName = "Input/InputContext")]
    public class InputContext : ScriptableObject
    {
        [Header("Player")] 
        public Vector2 Move;
        public Vector2 Look;
        public InputActionState Jump;
        public InputActionState Sprint;
        public InputActionState Crouch;
        public InputActionState Interact;
        public InputActionState Attack;
        public InputActionState SecondaryAttack;
        public InputActionState Reload;
        public InputActionState Inventory;
        public InputActionState UseItem;
        public InputActionState FreeLook;
        public int SwitchWeapon;
        
        [Header("Vehicle")] 
        public float Steering;
        public float Throttle;
        public float Brake;
        public InputActionState Handbrake;
        public InputActionState ExitVehicle;
        public InputActionState SwitchSeat;
        public InputActionState Horn;
        public InputActionState LightsToggle;
        public InputActionState VehicleWeaponFire;
        public InputActionState SwitchCamera;
        public Vector2 VehicleLook;
        
        [Header("UI")] 
        public Vector2 Navigate;
        public InputActionState Confirm;
        public InputActionState Cancel;
        public Vector2 Point;
        public Vector2 ScrollWheel;
        
        [Header("Global")] 
        public InputActionState Pause;
        public InputActionState OpenMap;
        public InputActionState OpenPhone;
        public InputActionState QuickSave;
        public InputActionState QuickLoad;
    }
}
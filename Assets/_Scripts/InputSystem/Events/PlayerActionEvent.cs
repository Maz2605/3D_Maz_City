using UnityEngine;
namespace _Scripts.InputSystem.Events
{
    public struct MoveInputEvent
    {
        public Vector2 Direction;
    }

    public struct LookInputEvent
    {
        public Vector2 Direction;
    }
    public struct JumpInputEvent
    {
        public InputActionPhase Phase;
    }

    public struct SprintInputEvent
    {
        public bool IsSprinting;
    }

    public struct CrouchInputEvent
    {
    }

    public struct InteractInputEvent
    {
    }

    public struct AttackInputEvent
    {
        public bool IsAttacking;
    }

    public struct SecondaryAttackInputEvent
    {
        public bool IsAttacking;
    }

    public struct SwitchWeaponInputEvent
    {
        public float SwitchValue;
    }

    public struct FreeLookInputEvent
    {
        public bool IsFreeLook;
    }

    public struct InventoryInputEvent
    {
    }
    
    public struct UseItemInputEvent
    {
            
    }

    public struct SwitchCameraInputEvent
    {
        public float SwitchValue;
    }

    public struct ReloadInputEvent
    {
        
    }
}
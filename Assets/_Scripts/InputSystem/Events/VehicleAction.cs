using UnityEngine;

namespace _Scripts.InputSystem.Events
{
    public struct SteeringInputEvent
    {
        public float Steering;
    }

    public struct ThrottleInputEvent
    {
        public float Throttle;
    }

    public struct BrakeInputEvent
    {
        public float Brake;
    }

    public struct HandBrakeInputEvent
    {
        public bool IsBrake;
    }

    public struct VehicleLookInputEvent
    {
        public Vector2 Direction;
    }

    public struct VehicleFreeLookInputEvent
    {
        public bool IsFreeLook;
    }

    public struct ExitVehicleInputEvent
    {
        
    }

    public struct SwitchSeatInputEvent
    {
        
    }

    public struct HornInputEvent
    {
        
    }

    public struct LightningInputEvent
    {
        
    }

    public struct VehicleWeaponInputEvent
    {
        
    }

    
}
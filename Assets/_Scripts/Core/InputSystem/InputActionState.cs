using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Core.InputSystem
{
    [SerializeField]
    public struct InputActionState
    {
        public bool Pressed;
        public bool Down;
        public bool Up;
        
        public void UpdateState(InputAction action)
        {
            Pressed = action.IsPressed();
            Down = action.WasPressedThisFrame();
            Up = action.WasReleasedThisFrame();
        }

    }
}
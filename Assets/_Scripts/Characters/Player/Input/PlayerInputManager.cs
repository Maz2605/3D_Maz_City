using System;
using _Scripts.InputSystem.Readers;
using UnityEngine;

namespace _Scripts.Characters.Player.Input
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader playerInputReader;
        [SerializeField] private VehicleInputReader vehicleInputReader;
        [SerializeField] private UIInputReader uiInputReader;
        
        public PlayerInputReader PlayerInput { get; private set; }
        public VehicleInputReader VehicleInput { get; private set; }
        public UIInputReader UIInput { get; private set; }

        private void Awake()
        {
            PlayerInput = playerInputReader;
            VehicleInput = vehicleInputReader;
            UIInput = uiInputReader;
        }
        
    }
}
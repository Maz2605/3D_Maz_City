using _Scripts.DesignPattern.StateMachine;
using _Scripts.InputSystem.Readers;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States.InVehicleState
{
    public class InVehicleState : BaseState
    {
        [SerializeField] private VehicleInputReader VehicleInputReader;

        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            
            VehicleInputReader.EnableActions();
        }

        public override void Execute(MonoBehaviour controller)
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit(MonoBehaviour controller)
        {
            base.OnExit(controller);
            
            VehicleInputReader.DisableActions();
        }
    }
}
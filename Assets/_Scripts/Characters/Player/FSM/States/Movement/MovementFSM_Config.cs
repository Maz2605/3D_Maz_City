using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States.Movement
{
    [CreateAssetMenu(fileName = "MovementFSM_Config", menuName = "FSM/Configs/MovementFSM_Config")]
    public class MovementFsmConfig : ScriptableObject
    {
        public BaseState initialState;
        public BaseState idleState;
        public BaseState walkState;

        public BaseState runState;

        // public BaseState CrouchState;
        public BaseState jumpState;

        public BaseState chargingJumpState;
        // public BaseState ClimbState;
    }
}
using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Project.FSM.Player
{
    [CreateAssetMenu(fileName = "MovementFSM_Config", menuName = "FSM/Configs/MovementFSM_Config")]
    public class MovementFsmConfig : ScriptableObject
    {
        public BaseState InitialState;
        
        public BaseState IdleState;
        public BaseState WalkState;
        public BaseState RunState;
        // public BaseState CrouchState;
        public BaseState JumpState;
        // public BaseState ClimbState;
    }
}
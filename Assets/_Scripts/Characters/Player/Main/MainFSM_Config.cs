using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Scripts.Characters.Player.Main  
{
    [CreateAssetMenu(fileName = "MainFSM_Config", menuName = "FSM/Configs/MainFSM_Config")]
    public class MainFsmConfig : ScriptableObject
    {
        public BaseState OnFootState;
        // public BaseState InVehicleState;
        public BaseState InitialState;
    }
}
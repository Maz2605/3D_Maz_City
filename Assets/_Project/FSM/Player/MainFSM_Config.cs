using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Project.FSM  
{
    [CreateAssetMenu(fileName = "MainFSM_Config", menuName = "FSM/Configs/MainFSM_Config")]
    public class MainFsmConfig : ScriptableObject
    {
        public BaseState OnFootState;
        // public BaseState InVehicleState;
        public BaseState InitialState;
    }
}
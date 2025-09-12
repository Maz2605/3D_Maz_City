using _Scripts.Characters.Player.Main;
using UnityEngine;

namespace _Scripts.DesignPattern.StateMachine
{
    public class MainFsm : MonoBehaviour
    {
        public MainFsmConfig config;
    
        public MovementFSM MovementFsm {get; private set; }
        public BaseState CurrentState { get; private set; }


        private void Awake()
        {
            MovementFsm = GetComponent<MovementFSM>();
        }
    
        private void Start()
        {
            if (config == null) return;
            CurrentState = config.InitialState;
        
            CurrentState?.OnEnter(this);
        }

        private void Update()
        {
            CurrentState?.Execute(this);
        }
    
        public void TransitionToState(BaseState newState)
        {
            CurrentState?.OnExit(this);
            CurrentState = newState;
            CurrentState.OnEnter(this);
        }
    }
}

using UnityEngine;

namespace _Scripts.DesignPattern.StateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        private IState _currentState;

    
        public void Initialize(IState initialState)
        {
            _currentState = initialState;
            _currentState.Initialize();
            _currentState.Enter();
        }
    
        public void ChangeState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
        private void Update()
        {
            _currentState?.Execute();
        }
    }
}

using UnityEngine;

namespace _Scripts.DesignPattern.StateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState initialState;
        private BaseState currentState;

        private void Start()
        {
            if (initialState != null)
            {
                TransitionToState(initialState);
            }
        }

        private void Update()
        {
            currentState?.Execute(this);
        }

        public void TransitionToState(BaseState newState)
        {
            if (newState == null || newState == currentState) return;

            currentState?.OnExit(this);
            currentState = newState;
            currentState.OnEnter(this);
        }
    }
}

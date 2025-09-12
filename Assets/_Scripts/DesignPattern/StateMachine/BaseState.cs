using UnityEngine;

namespace _Scripts.DesignPattern.StateMachine
{
    public abstract class BaseState : ScriptableObject 
    {
        public virtual void OnEnter(MonoBehaviour controller)
        {
            Debug.Log("Enter " + this.name);
        }
        public abstract void Execute(MonoBehaviour controller);
        public virtual void OnExit(MonoBehaviour controller){ }
    }
}

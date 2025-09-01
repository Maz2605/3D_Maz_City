using System;
using _Scripts.Core.InputSystem;
using _Scripts.DesignPattern.StateMachine;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States
{
    public class P_BaseState : BaseState
    {
        [SerializeField]
        protected InputContext InputContext;
        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            Debug.Log("Enter " + this.name);
        } 
        public override void Execute(MonoBehaviour controller)
        {
        }
    }
}
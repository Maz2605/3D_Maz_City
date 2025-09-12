using _Scripts.DesignPattern.StateMachine;
using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM.States.Movement
{
    [CreateAssetMenu(fileName = "RuningState", menuName = "FSM/States/RuningState")]
    public class P_RuningState : BaseState
    {
       private MovementFSM _movementFsm;

       public override void OnEnter(MonoBehaviour controller)
       {
           base.OnEnter(controller);
           _movementFsm = (MovementFSM)controller;
           
           EventManager.Instance.Subscribe<JumpInputEvent>(HandleJump);
           EventManager.Instance.Subscribe<SprintInputEvent>(HandleSprint);
       }

       public override void Execute(MonoBehaviour controller)
       {

           Vector2 moveInput = _movementFsm.CurrentMoveInput;

           if (moveInput == Vector2.zero)
           {
               _movementFsm.TransitionToState(_movementFsm.config.walkState);
           }
           
           Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y).normalized;
           _movementFsm.Controller.Move(movement * _movementFsm.Character.RunSpeed * Time.deltaTime);
           
           if(movement != Vector3.zero)
               _movementFsm.transform.forward = movement;
           
           //Anim
        }

       public void HandleJump(JumpInputEvent evt)
       {
           if(_movementFsm.isGrounded)
               _movementFsm.TransitionToState(_movementFsm.config.jumpState);
       }

       public void HandleSprint(SprintInputEvent evt)
       {
           if(!evt.IsSprinting)
               _movementFsm.TransitionToState(_movementFsm.config.walkState);
       }
    }
}
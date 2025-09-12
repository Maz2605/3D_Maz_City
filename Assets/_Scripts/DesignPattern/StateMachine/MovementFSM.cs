using System;
using _Scripts.Characters.Player.FSM.States.Movement;
using _Scripts.DesignPattern.StateMachine;
using _Scripts.InputSystem.EventManager;
using _Scripts.InputSystem.Events;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Character))]
public class MovementFSM : MonoBehaviour
{
    public MovementFsmConfig config;
    public BaseState CurrentState { get; private set; }
    
    public Character Character { get; private set; }
    public CharacterController Controller => Character.Controller;
    public Animator Animator => Character.Anim;
    public Vector2 CurrentMoveInput { get; private set; }

    public Vector3 PlayerVelocity;
    public bool isGrounded;
    private void Awake()
    {
        Character = GetComponent<Character>();
        
    }

    private void OnEnable()
    {
        if (config == null) return;
        CurrentState = config.initialState;
        CurrentState.OnEnter(this);
        
        EventManager.Instance.Subscribe<MoveInputEvent>(HandleMove);
    }

    private void Update()
    {
        isGrounded = Controller.isGrounded;
        if (isGrounded && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = -2.0f;
        }
        
        CurrentState?.Execute(this);
        
        PlayerVelocity.y += Character.Gravity * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);
    }

    private void OnDisable()
    {
        EventManager.Instance.Unsubscribe<MoveInputEvent>(HandleMove);
    }

    public void TransitionToState(BaseState nextState)
    {
        CurrentState?.OnExit(this);
        CurrentState = nextState;
        CurrentState.OnEnter(this);
    }

    private void HandleMove(MoveInputEvent evt)
    {
        CurrentMoveInput = evt.Direction;
    }
}
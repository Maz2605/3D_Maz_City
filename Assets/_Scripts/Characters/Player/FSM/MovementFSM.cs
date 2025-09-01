using _Project.FSM.Player;
using _Scripts.DesignPattern.StateMachine;
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

    public Vector3 PlayerVelocity;
    public bool isGrounded;
    private void Awake()
    {
        Character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        if (config == null) return;
        CurrentState = config.InitialState;
        CurrentState.OnEnter(this);
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

    public void TransitionToState(BaseState nextState)
    {
        CurrentState?.OnExit(this);
        CurrentState = nextState;
        CurrentState.OnEnter(this);
    }
}
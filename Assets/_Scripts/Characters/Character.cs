using System;
using _Scripts.Characters;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] 
    private CharacterType characterType;
    
    public float WalkSpeed { get; private set; }
    public float RunSpeed { get; private set; }
    public float CrouchSpeed { get; private set; }
    public float JumpHeight { get; private set; }
    public float Gravity { get; private set; }
    
    public CharacterController Controller { get; private set; }
    public Animator Anim { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Anim = GetComponentInChildren<Animator>();

        if (characterType == null)
        {
            Debug.LogError("CharacterType is not assigned in the inspector.", this);
            return;
        }

        InitializeStats();
    }
    
    public void InitializeStats()
    {
        WalkSpeed = characterType.walkSpeed;
        RunSpeed = characterType.runSpeed;
        CrouchSpeed = characterType.crouchSpeed;
        JumpHeight = characterType.jumpHeight;
        Gravity = characterType.gravity;
    }
}

using UnityEngine;

public interface IState 
{
    void Initialize();
    void Enter();
    void Execute();
    void Exit();
}

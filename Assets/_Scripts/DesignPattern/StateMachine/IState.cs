namespace _Scripts.DesignPattern.StateMachine
{
    public interface IState 
    {
        void Initialize();
        void Enter();
        void Execute();
        void Exit();
    }
}

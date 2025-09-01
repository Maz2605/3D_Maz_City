using _Scripts.DesignPattern.StateMachine;
using UnityEngine;

namespace _Scripts.Characters.Player.FSM
{
    [CreateAssetMenu(fileName = "OnFootState", menuName = "FSM/States/OnFootState")]
    public class OnFootState : BaseState
    {
        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            MainStateMachine mainFsm = controller as MainStateMachine;

            if (mainFsm?.MovementFsm != null)
            {
                mainFsm.MovementFsm.enabled = true;
            }
        }

        public override void Execute(MonoBehaviour controller)
        {
            
        }

        public override void OnExit(MonoBehaviour controller)
        {
            base.OnExit(controller);
            MainStateMachine mainFSM = controller as MainStateMachine;
            if (mainFSM.MovementFsm != null)
            {
                mainFSM.MovementFsm.enabled = false;
            }
        }
    }
}
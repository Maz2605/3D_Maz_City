using _Scripts.InputSystem;
using _Scripts.InputSystem.Readers;
using UnityEngine;

namespace _Scripts.DesignPattern.StateMachine
{
    [CreateAssetMenu(fileName = "OnFootState", menuName = "FSM/States/OnFootState")]
    public class OnFootState : BaseState
    {
        [SerializeField] private PlayerInputReader playerInputReader;
        public override void OnEnter(MonoBehaviour controller)
        {
            base.OnEnter(controller);
            Debug.Log("<color=green>OnFootState: ENTERED. Enabling MovementFSM and PlayerInputReader.</color>");
            MainFsm mainFsm = controller as MainFsm;
            
            mainFsm!.MovementFsm.enabled = true;
            
            playerInputReader.EnableActions();
        }

        public override void Execute(MonoBehaviour controller)
        {
            
        }

        public override void OnExit(MonoBehaviour controller)
        {
            base.OnExit(controller);
            MainFsm mainFsm = controller as MainFsm;

            if (mainFsm.MovementFsm != null)
            {
                mainFsm.MovementFsm.enabled = false;
            }

            if (playerInputReader != null)
            {
                playerInputReader.DisableActions();
            }
        }
    }
}
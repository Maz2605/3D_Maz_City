using _Scripts.Core.InputSystem;
using UnityEngine;

namespace _Scripts.Player.Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] InputContext _inputContext;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(InputRouter.Instance.CurrentInputMap);
            }
        
            if(_inputContext.Jump.Down)
                Debug.Log("Jump Pressed");
            if(_inputContext.Jump.Pressed)
                Debug.Log("Jump Held");
        }
    }
}

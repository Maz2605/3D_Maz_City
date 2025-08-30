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
        
            if(_inputContext.SwitchWeapon > 0)
                Debug.Log("Next Weapon");
            else if(_inputContext.SwitchWeapon < 0)
                Debug.Log("Previous Weapon");
        }
    }
}

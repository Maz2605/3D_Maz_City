using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputReader : ScriptableObject
{
     protected InputActionControls InputControls;
     

     protected virtual void OnEnable()
     {
          if (InputControls == null)
               InputControls = new InputActionControls();
     }

     public virtual void EnableActions()
     {
          
     }

     public virtual void DisableActions()
     {
          
     }
     
     
}

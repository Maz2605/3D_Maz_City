using System;
using System.Collections.Generic;
using _Scripts.DesignPattern.Singleton;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Core.InputSystem
{
    public class InputRouter : Singleton<InputRouter>
    {
        private InputActionControls _inputActionControls;
        public InputActionControls InputActionControls => _inputActionControls;
        private readonly Stack<InputActionMap> _inputMapStack = new ();
        protected override void Awake()
        {
            base.Awake();
            KeepAlive(true);
            _inputActionControls = new InputActionControls();
        }

        private void OnEnable()
        {
            _inputActionControls.Global.Enable();
            PushInputMap(ActionMapName.Player.ToString());
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            foreach (var map in _inputMapStack)
            {
                map.Disable();
            }
            _inputMapStack.Clear();
            _inputActionControls.Global.Disable();
        }
        
        public void PushInputMap(string mapName)
        {
           if(_inputMapStack.Count > 0)
               _inputMapStack.Peek().Disable();
           
            var map = _inputActionControls.asset.FindActionMap(mapName, true);
            map.Enable();
            _inputMapStack.Push(map);
        }
        
        public void PopInputMap()
        {
            if (_inputMapStack.Count == 0) return;
            
            var topMap = _inputMapStack.Pop();
            topMap.Disable();
            
            if (_inputMapStack.Count > 0)
            {
                _inputMapStack.Peek().Enable();
            }
        }
        
        public InputActionMap CurrentInputMap => _inputMapStack.Count > 0 ? _inputMapStack.Peek() : null;
    }
}

using System;
using _Scripts.DesignPattern.Singleton;
using DebugTools.Core;
using UnityEngine;

namespace _DebugTools.Scripts.Core
{
    public class DebugHUDManager : Singleton<DebugHUDManager>
    {
        [SerializeField] private DebugConfig config;
        [SerializeField] private GameObject hudRoot;
        [SerializeField] private GameObject consoleRoot;
        
        public bool HudVisible { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();
            KeepAlive(true);
            
            if (!config) config = Resources.Load<DebugConfig>("DebugConfig");
            HudVisible = config ? config.startHudVisible : true;
            if (hudRoot) hudRoot.SetActive(HudVisible);
            if (consoleRoot) consoleRoot.SetActive(false);
        }

        void Update()
        {
            if (!config) return;
            if (Input.GetKeyDown(config.toggleHUD))     ToggleHUD();
            if (Input.GetKeyDown(config.toggleConsole)) ToggleConsole();
        }

        public void ToggleHUD()
        {
            HudVisible = !HudVisible;
            if (hudRoot) hudRoot.SetActive(HudVisible);
        }

        public void ToggleConsole()
        {
            if (!consoleRoot) return;
            consoleRoot.SetActive(!consoleRoot.activeSelf);
        }
    }
}

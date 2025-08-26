using System;
using DebugTools.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _DebugTools.Scripts.Core
{
    [DefaultExecutionOrder(-100)]
    public class DebugSceneAutoLoader : MonoBehaviour
    {
        [SerializeField] private string overlaySceneName = "DebugHUDScene";
        [SerializeField] private DebugConfig config;

        static bool s_Attempted;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (config == null) config = Resources.Load<DebugConfig>("DebugConfig");

#if UNITY_EDITOR
            if (!config || !config.loadInEditor) return;
            TryLoadOnce();
#else
            if (Debug.isDebugBuild && config && config.loadInDevelopmentBuild)
                TryLoadOnce();
#endif
        }

        void Update()
        {
            if (config && Input.GetKeyDown(config.toggleOverlay))
                ToggleOverlay();
        }

        void TryLoadOnce()
        {
            if (s_Attempted) return;
            s_Attempted = true;
            if (!SceneManager.GetSceneByName(overlaySceneName).isLoaded)
                SceneManager.LoadSceneAsync(overlaySceneName, LoadSceneMode.Additive);
        }

        void ToggleOverlay()
        {
            var s = SceneManager.GetSceneByName(overlaySceneName);
            if (s.IsValid() && s.isLoaded)
                SceneManager.UnloadSceneAsync(overlaySceneName);
            else
                SceneManager.LoadSceneAsync(overlaySceneName, LoadSceneMode.Additive);
        }
    }
}

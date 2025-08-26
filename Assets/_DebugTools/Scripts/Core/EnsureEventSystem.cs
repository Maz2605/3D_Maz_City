using UnityEngine;
using UnityEngine.EventSystems;

namespace _DebugTools.Scripts.Core
{
    [DefaultExecutionOrder(-200)]
    public class EnsureEventSystem : MonoBehaviour
    {
        void Awake()
        {
            if (FindAnyObjectByType<EventSystem>()) return;
            var go = new GameObject("EventSystem (Auto)");
            DontDestroyOnLoad(go);
#if ENABLE_INPUT_SYSTEM
            go.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
#else
            go.AddComponent<StandaloneInputModule>();
#endif
        }
    }
}
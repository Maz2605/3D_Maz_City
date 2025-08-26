using _DebugTools.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using DebugTools.Core;

namespace _DebugTools.Scripts.Modules
{
    public class DebugShortcuts : MonoBehaviour
    {
        [SerializeField] DebugConfig config;
        void Awake(){ if(!config) config = Resources.Load<DebugConfig>("DebugConfig"); }

        void Start()
        {
            DebugConsole.Instance?.Register("reload", _ =>
            {
                var s = SceneManager.GetActiveScene();
                SceneManager.LoadScene(s.buildIndex);
            });
            DebugConsole.Instance?.Register("timescale", _ => {}); // đã có ở console base
        }
    }
}
using UnityEngine;

namespace DebugTools.Core
{
    [CreateAssetMenu(menuName = "DebugTools/Config", fileName = "DebugConfig")]
    public class DebugConfig : ScriptableObject
    {
        [Header("Overlay load rules")]
        public bool loadInEditor = true;
        public bool loadInDevelopmentBuild = true;

        [Header("Canvas")]
        public int canvasOrder = 5000;     // để “đè” lên UI game

        [Header("Hotkeys")]
        public KeyCode toggleOverlay = KeyCode.F10;
        public KeyCode toggleHUD     = KeyCode.F1;
        public KeyCode toggleConsole = KeyCode.BackQuote; // ~
        public KeyCode tpNext        = KeyCode.F7;
        public KeyCode tpPrev        = KeyCode.F6;

        [Header("Defaults")]
        public bool startHudVisible = true;
    }
}
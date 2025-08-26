using UnityEngine;

namespace _DebugTools.Scripts.Core
{
    public class PlayerLocator : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] string fallbackTag = "Player";

        public Transform Get()
        {
            if(player) return player;
            var go = GameObject.FindGameObjectWithTag(fallbackTag);
            return go ? go.transform : null;
        }
    }
}
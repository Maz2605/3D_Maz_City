using UnityEngine;

namespace _Scripts.Characters
{
    [CreateAssetMenu(fileName = "CharacterType", menuName = "Character/CharacterType")]
    public class CharacterType : ScriptableObject
    {
        [Header("Base Stats")] public float walkSpeed = 3.5f;
        public float runSpeed = 7f;
        public float crouchSpeed = 2f;
        public float jumpHeight = 1.5f;
        public float gravity = -9.81f;
    }
}
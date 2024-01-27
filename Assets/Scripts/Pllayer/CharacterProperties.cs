using UnityEngine;



namespace Player 
{
    [CreateAssetMenu(fileName = "CharacterProperties", menuName = "CharacterProperties", order = 0)]
    public class CharacterProperties : ScriptableObject {
        [Range(0, 25)]
        public float speed = 5f;
        [Range(0, 25)]
        public float jumpForce = 8f;



        public GameObject character;




        public bool upWorld = false;
    }
}
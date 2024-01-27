using UnityEngine;

public enum CharacterType {
    Ciger,
    AdanaDurum
}

namespace Player 
{
    [CreateAssetMenu(fileName = "CharacterProperties", menuName = "CharacterProperties", order = 0)]
    public class CharacterProperties : ScriptableObject {
        
        public CharacterType characterType;
        
        [Range(0, 25)]
        public float speed = 5f;
        [Range(0, 25)]
        public float jumpForce = 8f;



        public Sprite characterSprite;




        public bool upWorld = false;

    }
}
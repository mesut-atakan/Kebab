using UnityEngine;



namespace Player
{
    internal class CharacterManager : MonoBehaviour
    {
        public CharacterProperties characterProperties;
        [SerializeField] private byte characterHealth = 3;


        private Obstacle contactObstacle;


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Block"))
            {
                this.contactObstacle = other?.GetComponent<Obstacle>();

                HealthReduce();
            }
        }






        private byte HealthReduce()
        {
            if (this.characterHealth > 1)
                this.characterHealth--;
            else {
                this.characterHealth = 0;
                LevelManager.ChangeScene(LevelManager.CurrentLevelName);
            }
            Debug.Log($"Health: {this.characterHealth}", this.gameObject);
            return characterHealth;
        }
    }
}
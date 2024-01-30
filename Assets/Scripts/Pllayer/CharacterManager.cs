using System.Collections;
using UnityEngine;



namespace Player
{
    internal class CharacterManager : MonoBehaviour
    {
        public CharacterProperties characterProperties;
        public SpriteRenderer characterSprite;


        public float takeDamagePower = 4f;




        [SerializeField] private byte characterHealth = 3;


        public Transform[] healthTransform = new Transform[3];

        public Transform[] cigerObject;
        public Transform[] durumObject;


        private Obstacle contactObstacle;


        [Header("Damage Duration")]

        public float damageDuration = 1.5f;


        [Header("Classes")]
        public GameManager gameManager;



        public Sprite ChangeSprite {
            set {
                this.characterSprite.sprite = value;
            }
        }




        private void Start() {
            characterHealth = 3;
            HealthBar();
        }








        private void OnDrawGizmos() {
            Gizmos.color = Color.black;
            
            foreach (Transform _healthTransform in this.healthTransform)
                Gizmos.DrawSphere(_healthTransform.position, 0.2f);
        }


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Block"))
            {
                this.contactObstacle = other?.GetComponent<Obstacle>();

                TakeDamage();
            }
            else if (other.CompareTag("Finish"))
            {
                LevelManager.ChangeScene(LevelManager.CurrentLevelIndex);
            }
        }



        private void TakeDamage()
        {
            TakeDamageAnimation();
            HealthReduce();
        }

        private void TakeDamageAnimation()
        {
            GameObject obj;
            Rigidbody2D rb;
            if (this.characterProperties.characterType == CharacterType.Ciger)
            {
                obj = this.cigerObject[characterHealth - 1].gameObject;
                obj.transform.parent = null;
                rb = obj.GetComponent<Rigidbody2D>();
                rb.simulated = true;
                rb.AddForce(Vector2.up * this.takeDamagePower, ForceMode2D.Impulse);
                Destroy(obj.gameObject, 20f);
            }
            else
            {
                obj = this.durumObject[characterHealth - 1].gameObject;
                obj.transform.parent = null;
                rb = obj.GetComponent<Rigidbody2D>();
                rb.simulated = true;
                rb.AddForce(Vector2.up * this.takeDamagePower, ForceMode2D.Impulse);
                Destroy(obj.gameObject, 20f);
            }
        }


        private byte HealthReduce()
        {
            if (this.characterHealth > 1)
                this.characterHealth--;
            else {
                this.characterHealth = 0;
                StartCoroutine(this.gameManager.Losser());
                // LevelManager.ChangeScene(LevelManager.CurrentLevelName);
            }
            Debug.Log($"Health: {this.characterHealth}", this.gameObject);
            return characterHealth;
        }







        public void HealthIncrease(byte value)
        {
            if (value >= 3)
                this.characterHealth = 3;
            else if (value != 0) {
                this.characterHealth += value;
            }
            else if (value <= 0) {
                Debug.LogError("Wrong Value Entered!");
                return;
            }

        }








        public void HealthBar()
        {
            HealthBarSetActive(CharacterType.Ciger, false);
            HealthBarSetActive(CharacterType.AdanaDurum, false);

            if (this.characterProperties.characterType == CharacterType.Ciger)
            {
                for (int i = 0; i < this.characterHealth; i++)
                {
                    this.cigerObject[i].gameObject.SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < this.characterHealth; i++)
                {
                    this.durumObject[i].gameObject.SetActive(true);
                }
            }
        }




        private void HealthBarSetActive(CharacterType characterType, bool value)
        {
            if (characterType == CharacterType.Ciger)
            {
                foreach (Transform obj in this.cigerObject)
                {
                    obj.gameObject.SetActive(value);
                }
            }
            else
            {
                foreach (Transform obj  in this.durumObject)
                {
                    obj.gameObject.SetActive(value);
                }
            }
        }
    }
}
using UnityEngine;



namespace Player 
{
    [RequireComponent (typeof (Rigidbody2D))]
    internal class PlayerController : MonoBehaviour
    {
        public string horizontalAxisName = "Horizontal";
        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode switchKey = KeyCode.R;



        [Header("Components")]

        public Rigidbody2D rb;



        [Header("Classes")]

        public GameManager gameManager;
        public CharacterManager characterManager;







#region PRIVATE FIELDS

        float _horizontalAxis;
        const float speedMultiply = 100;

#endregion




        public void CharacterController()
        {
            _horizontalAxis = Input.GetAxis(this.horizontalAxisName) * this.characterManager.characterProperties.speed * Time.deltaTime * speedMultiply;

            this.rb.velocity = new Vector2(_horizontalAxis, this.rb.velocity.y);
        }


        public void CharacterJump()
        {
            if (Input.GetKeyDown(this.jumpKey))
            {
                this.rb.AddForce(Vector2.up * this.characterManager.characterProperties.jumpForce, ForceMode2D.Impulse);
            }
        }



        public void Switch()
        {
            if (!Input.GetKeyDown(this.switchKey)) return;
            
            this.gameManager.cameraController.axisChange = true;
            if (this.characterManager.characterProperties == this.gameManager.characters[0])
            {
                this.characterManager.characterProperties = this.gameManager.characters[1];
            }
            else {
                this.characterManager.characterProperties = this.gameManager.characters[0];
            }

        }
    }
}
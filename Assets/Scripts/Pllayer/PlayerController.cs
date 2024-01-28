using Unity.VisualScripting;
using UnityEngine;


namespace Player 
{
    [RequireComponent (typeof (Rigidbody2D))]
    internal class PlayerController : MonoBehaviour
    {
        public string horizontalAxisName = "Horizontal";
        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode switchKey = KeyCode.R;

        [Header("Ground Check")]

        public Transform groundCheckTransform;
        public Vector2 groundCheckSize = new Vector2(0.6f, 0.1f);
        public LayerMask groundLayer;


        [Header("Components")]

        public Rigidbody2D rb;


        [Header("Classes")]

        public GameManager gameManager;
        public CharacterManager characterManager;



#region SWITCH

        private bool _isSwitch = true;

#endregion



#region PRIVATE FIELDS

        float _horizontalAxis;
        const float speedMultiply = 100;
        internal float _speedDecrease { get; set; } = 0;






#endregion




        public bool GroundCheck {
            get {
                return Physics2D.OverlapBox(this.groundCheckTransform.position, this.groundCheckSize, 0, this.groundLayer);
            }
        }








        private void OnDrawGizmos() {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(this.groundCheckTransform.position, this.groundCheckSize);
        }




        public void CharacterController()
        {
            _horizontalAxis = Input.GetAxis(this.horizontalAxisName) * this.characterManager.characterProperties.speed * Time.deltaTime * speedMultiply + this._speedDecrease;

            this.rb.velocity = new Vector2(_horizontalAxis, this.rb.velocity.y);
        }


        public void CharacterJump()
        {
            if (Input.GetKeyDown(this.jumpKey) && this.GroundCheck)
            {
                this.rb.AddForce(Vector2.up * this.characterManager.characterProperties.jumpForce, ForceMode2D.Impulse);
            }
        }



        public void Switch()
        {
            if (Input.GetKeyDown(this.switchKey))
            {
                this.gameManager.cameraController.axisChange = true;
                if (this.characterManager.characterProperties == this.gameManager.characters[0])
                {
                    this.characterManager.characterProperties = this.gameManager.characters[1];
                }
                else if (this._isSwitch){
                    this.characterManager.characterProperties = this.gameManager.characters[0];
                    this._isSwitch = false;
                }

                // this.characterManager.ChangeSprite = this.characterManager.characterProperties.characterSprite;

                this.characterManager.HealthBar();
                this.gameManager.audioManager.ChangeMussic();
                
            }
        }


        private float _currentCoolDown = 0.0f;
        private float _maxCoolDown = 10.0f;

        public void SwitchCoolDown()
        {
            if (this._currentCoolDown <= _maxCoolDown)
            {
                _currentCoolDown += Time.deltaTime;
                Debug.Log(_currentCoolDown.ToString());
            }
            else{
                this._isSwitch = true;
                _currentCoolDown = 0;
            }
        }


        private void Update() {
            if (!this._isSwitch)
                SwitchCoolDown();
        }
    }
}
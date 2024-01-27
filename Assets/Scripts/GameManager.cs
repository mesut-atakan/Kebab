using Player;
using UnityEngine;



[RequireComponent (typeof (CameraController))]
internal class GameManager : MonoBehaviour
{
    public CharacterProperties[] characters = new CharacterProperties[2];



    [Header("Classes")]
    public PlayerController playerController;
    public CameraController cameraController;





    private void Awake() {
        
        if (this.playerController == null)
            this.playerController = FindObjectOfType<PlayerController>();
        if (this.playerController.rb == null)
            this.playerController.rb = this.playerController.gameObject.GetComponent<Rigidbody2D>();
        if (this.cameraController == null)
            this.cameraController = FindObjectOfType<CameraController>();
        if (CameraController.camera == null)
            CameraController.camera = Camera.main;
        
        
        
        this.playerController.rb.freezeRotation = true;
    }

    private void OnEnable() {
    }

    private void OnDisable() {
    }



    private void FixedUpdate() {
        this.playerController.CharacterController();
        LevelManager.TimeSpeed();
        // Debug.Log($"Time Speed: {Time.timeScale}");
    }





    private void Update() {
        this.playerController.CharacterJump();
        this.playerController.Switch();


        this.cameraController.CameraChange(this.playerController.characterManager.characterProperties.upWorld);

    }





    private void LateUpdate() {
        this.cameraController.CameraMove();
    }










    public void Losser()
    {
        Debug.Log("<color=red>LOSSER</color>", this.gameObject);
    }
}
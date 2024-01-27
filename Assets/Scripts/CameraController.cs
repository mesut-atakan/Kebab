using Unity.VisualScripting;
using UnityEngine;



namespace Player {
    internal  class CameraController : MonoBehaviour
    {
        public new static Camera camera;
        public float moveSmothness = 0.06f;
        public float axisChangeSmothness = 0.7f;
        public Transform targetTransform;
        [SerializeField] private bool isAxis = true;



        [HideInInspector]
        public bool axisChange = false;



        public  void CameraMove()
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(this.targetTransform.position.x, 0.0f, camera.transform.position.z), this.moveSmothness * Time.deltaTime);
        }





        public void CameraChange(bool value)
        {
            if (!this.axisChange || !this.isAxis) return;
            if (value)
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(0, 0.5f, camera.transform.position.z), axisChangeSmothness);
            }
            else
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(0, -9.5f, camera.transform.position.z), axisChangeSmothness);
            }

            if (Mathf.Abs(camera.transform.position.y - 0.5f) < 0.05f)
            {
                camera.transform.position = new Vector3(0.0f, 0.5f, camera.transform.position.z);
                this.axisChange = false;
            }
            else if (Mathf.Abs(camera.transform.position.y - 9.5f) < 0.05f)
            {
                camera.transform.position = new Vector3(0.0f, -9.5f, camera.transform.position.z);
                this.axisChange = false;
            }
        }
    }
}
using UnityEngine;



internal class Target : MonoBehaviour
{
    public Transform targetTransform;
    



    private void FixedUpdate() {
        this.transform.position = targetTransform.position;
    }
}
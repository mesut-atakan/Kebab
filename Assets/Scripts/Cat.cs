using System.Collections;
using UnityEngine;



internal class Cat : MonoBehaviour
{
    public Transform targetTrasnform;
    public float targetDistance;
    public float targetSmothness;

    public float _minDistance, _maxDistance;


    private bool randomDistance = false;


    public IEnumerator RandomDistance()
    {
        randomDistance = true;
        if (randomDistance == true)
        {
            this.targetDistance = Random.Range(_minDistance, _maxDistance);
            yield return new WaitForSeconds(6.5f);
            randomDistance = false;
        }
    }






    public void TargetPlayer()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.targetTrasnform.position.x - this.targetDistance, this.transform.position.y, 0), this.targetSmothness * Time.deltaTime);
    }


    private void Update() {
        TargetPlayer();
    }

    


}
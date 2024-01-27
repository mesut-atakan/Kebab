using UnityEngine;



internal enum ObstacleType {
    fire,
    punch
}
internal class Obstacle : MonoBehaviour
{
    public ObstacleType obstacleType;
}
using UnityEngine;

public class ObstaclePlacer : MonoBehaviour
{
    [SerializeField] private Transform obstacle;

    private void Start()
    {
        obstacle.position = new Vector3(transform.position.x, transform.position.y);
        obstacle.rotation = transform.rotation;
    }
}

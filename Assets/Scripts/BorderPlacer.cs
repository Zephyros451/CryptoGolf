using UnityEngine;

public class BorderPlacer : MonoBehaviour
{
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    private Vector2 topRightCorner;
    private Vector2 offset;

    private void Awake()
    {
        topRightCorner = new Vector2(Screen.width, Screen.height);
        topRightCorner = Camera.main.ScreenToWorldPoint(topRightCorner);
        offset = new Vector2(topRightCorner.x * 0.2f, topRightCorner.y * 0.1f);

        top.position = new Vector3(0, topRightCorner.y + offset.y, 0);
        bottom.position = new Vector3(0, -topRightCorner.y - offset.y, 0);
        left.position = new Vector3(-topRightCorner.x - offset.x, 0, 0);
        right.position = new Vector3(topRightCorner.x + offset.x, 0, 0);
    }
}

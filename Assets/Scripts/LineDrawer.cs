using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Ball ball;

    private void Start()
    {
        line.positionCount = 1;
        line.SetPosition(0, ball.transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && ball.isActive)
        {
            RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, ball.forceDirection, 1000, 1 << 8);
            if (hit)
            {
                line.positionCount = 2;
                line.SetPosition(1, hit.point);
            }

            float width = line.startWidth;
            line.material.mainTextureScale = new Vector2(1f / width, 1.0f);
        }
        else
        {
            line.positionCount = 1;
        }
    }
}

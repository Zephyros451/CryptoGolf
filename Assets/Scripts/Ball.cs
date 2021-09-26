using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform holeTransform;

    private const string hole = "Hole";
    private const string killWall = "KillWall";
    private float forceMultiplier = 100f;
    private Camera camera;

    private Rigidbody2D rb;
    private Vector2 start;
    private Vector2 end;

    public Vector2 forceDirection { get; private set; }
    public bool isActive { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        isActive = true;
    }

    private void WinSequence()
    {
        rb.velocity = Vector2.zero;
        Vector3 holePosition = new Vector3(holeTransform.position.x, holeTransform.position.y, -1f);
        DOTween.Sequence()
        .Append(transform.DOMove(holePosition, 0.3f))
        .Append(transform.DOScale(0f, 0.5f))
        .AppendCallback(SceneSwitcher.instance.LoadWinScene);
    }

    private void LoseSequence()
    {
        DOTween.Sequence()
        .Append(transform.DOScale(0f, 0.5f))
        .AppendCallback(SceneSwitcher.instance.LoadLoseScene);
    }

    private void Update()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                start = transform.position;
            }

            if (Input.GetMouseButton(0))
            {
                end = camera.ScreenToWorldPoint(Input.mousePosition);
                forceDirection = (end - start).normalized;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if ((end - start).sqrMagnitude < 0.25f)
                    return;

                rb.AddForce(forceDirection * forceMultiplier);
                forceDirection = Vector2.zero;
                isActive = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(killWall))
        {
            LoseSequence();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(hole))
        {
            WinSequence();
        }        
    }
}

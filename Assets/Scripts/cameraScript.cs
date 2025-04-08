using UnityEngine;

public class SlipperyCamera2D : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 3f;
    public float maxSpeed = 6f;
    public float drag = 1f;

    [Header("Zoom")]
    public float zoomSpeed = 5f;
    public float minZoom = 1f; 
    public float maxZoom = 3f;   

    [Header("Background Reference")]
    public SpriteRenderer background; 

    private Vector2 velocity = Vector2.zero;
    private Camera cam;

    private float minX, maxX, minY, maxY;

    void Start()
    {
        cam = GetComponent<Camera>();

        if (background != null)
        {
            Bounds bounds = background.bounds;
            minX = bounds.min.x;
            maxX = bounds.max.x;
            minY = bounds.min.y;
            maxY = bounds.max.y;
        }
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
        ClampToBackground();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 inputDir = new Vector2(moveX, moveY).normalized;

        if (inputDir != Vector2.zero)
        {
            velocity += inputDir * acceleration * Time.deltaTime;
            velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
        }

        velocity = Vector2.Lerp(velocity, Vector2.zero, drag * Time.deltaTime);
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            float targetZoom = cam.orthographicSize - scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }
    }

    void ClampToBackground()
    {
        if (background == null) return;

        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * cam.aspect;

        float clampedX = Mathf.Clamp(transform.position.x, minX + horzExtent, maxX - horzExtent);
        float clampedY = Mathf.Clamp(transform.position.y, minY + vertExtent, maxY - vertExtent);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
using UnityEngine;

public class SlipperyCamera2D : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 3f;
    public float maxSpeed = 6f;
    public float drag = 1f;

    [Header("Zoom")]
    public float zoomSpeed = 5f;
    public float minZoom = 1f;   // closer in
    public float maxZoom = 3f;           // Furthest zoom

    private Vector2 velocity = Vector2.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
            Debug.LogError("SlipperyCamera2D script must be attached to the Camera object!");
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
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
}
using UnityEngine;

public class Bacteria2Movement : MonoBehaviour
{
    public float moveSpeed = 0.5f;             // Slower speed
    public float moveDuration = 1f;            // Time to move in one direction
    public float restDuration = 2f;            // Time to rest between moves
    public float rotationSpeed = 50f;          // Degrees per second

    private Vector2 moveDirection;
    private float moveTimer = 0f;
    private float restTimer = 0f;
    private bool isMoving = false;

    void Start()
    {
        ChooseNewDirection();
        restTimer = Random.Range(0f, restDuration); // Start with a random rest offset
    }

    void Update()
    {
        // Rotate slowly
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (isMoving)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            moveTimer += Time.deltaTime;

            if (moveTimer >= moveDuration)
            {
                isMoving = false;
                restTimer = 0f;
            }
        }
        else
        {
            restTimer += Time.deltaTime;

            if (restTimer >= restDuration)
            {
                ChooseNewDirection();
                moveTimer = 0f;
                isMoving = true;
            }
        }
    }

    void ChooseNewDirection()
    {
        float angle = Random.Range(0f, 360f);
        float radians = angle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
    }
}

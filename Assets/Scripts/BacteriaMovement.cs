using UnityEngine;

public class BacteriaMovement : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 moveDirection;

    void Start()
    {
        float angle = Random.Range(0f, 360f);
        float radians = angle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}
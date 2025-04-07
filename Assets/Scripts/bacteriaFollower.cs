using UnityEngine;

public class BacteriaFollower : MonoBehaviour
{
    public Transform target;
    public float followDistance = 1f;
    public float followSpeed = 5f;

    void Update()
    {
        if (target == null) return;

        Vector2 toTarget = target.position - transform.position;
        float currentDistance = toTarget.magnitude;

        if (currentDistance > followDistance)
        {
            Vector2 direction = toTarget.normalized;
            float moveAmount = currentDistance - followDistance;
            Vector2 move = direction * moveAmount * followSpeed * Time.deltaTime;

            transform.position += (Vector3)move;
        }
    }
}

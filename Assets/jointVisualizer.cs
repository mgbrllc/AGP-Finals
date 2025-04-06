using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class jointVisualizer : MonoBehaviour
{
    public Transform target; // The other bacteria to connect to
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        if (target != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, target.position);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class jointVisualizer : MonoBehaviour
{
    public Transform target;
    public Joint2D jointToTrack;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;

        if (jointToTrack == null)
            jointToTrack = GetComponent<Joint2D>();

        line.sortingOrder = -1;
    }

    void Update()
    {
        if (jointToTrack == null)
        {
            line.enabled = false;
            return;
        }

        if (target != null)
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, target.position);
        }
        else
        {
            line.enabled = false;
        }
    }

    public void OnJointDestroyed()
    {
        if (jointToTrack != null)
        {
            Destroy(jointToTrack);         // ?? Destroy the joint
            jointToTrack = null;
        }

        if (line != null)
            line.enabled = false;          // Hide the line
    }

    public bool IsJointBroken()
    {
        return jointToTrack == null || !jointToTrack.enabled;
    }
}

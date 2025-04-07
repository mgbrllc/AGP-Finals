using UnityEngine;
using static level2Script;

public class BacteriaClones : MonoBehaviour
{
    public CloneGroup parentGroup;

    private void OnDestroy()
    {
        if (parentGroup != null)
        {
            parentGroup.NotifyCloneDestroyed();
        }
    }
}

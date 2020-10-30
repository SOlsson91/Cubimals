using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public GameObject target;
    public bool isActive = false;

    void Start()
    {
        if (target != null)
        {
            target.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("[ActivateButton]: Missing gameobject");
        }
    }

    public void ActivateTarget()
    {
        if (target == null)
        {
            Debug.LogWarning("[ActivateButton] Target is null");
            return;
        }
        isActive = !isActive;
        target.SetActive(isActive);
    }
}

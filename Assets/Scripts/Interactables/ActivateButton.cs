using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public GameObject target;
    private bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    void Start()
    {
        isActive = false;
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
        Debug.Log("ACTIVATED");
        isActive = !isActive;
        target.SetActive(isActive);
    }
}

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
        target.SetActive(isActive);
    }

    public void ActivateTarget()
    {
        Debug.Log("ACTIVATED");
        isActive = !isActive;
        target.SetActive(isActive);
    }
}

using UnityEngine;

public class Pushables : MonoBehaviour
{
    private void Awake()
    {
        foreach(GameObject push in GameObject.FindGameObjectsWithTag("Pushable"))
        {
            if (push.GetComponent<Rigidbody>() == null)
            {
                continue;
            }
            else
            {
                push.AddComponent<Rigidbody>();
                push.GetComponent<Rigidbody>().mass=100;
                push.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}

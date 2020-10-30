using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCam : MonoBehaviour
{
    public blaCam camera;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " is in cAVe");
        camera.inCave = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out of cave");
        camera.inCave = false;
    }
}

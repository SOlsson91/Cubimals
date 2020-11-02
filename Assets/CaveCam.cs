using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCam : MonoBehaviour
{
    public blaCam camera;

    private void OnTriggerEnter(Collider other)
    {
        camera.inCave = true;

        foreach (Player player in GameManager.Instance.players)
        {
            player.GetComponent<PlayerMove>().inCave = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        camera.inCave = false;

        foreach (Player player in GameManager.Instance.players)
        {
            player.GetComponent<PlayerMove>().inCave = false;
        }
    }
}

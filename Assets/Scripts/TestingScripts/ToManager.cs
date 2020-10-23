using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToManager : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ToManagerLoadScene(string sceneName)
    {
        
    }
}

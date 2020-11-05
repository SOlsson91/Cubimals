using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    public ParticleSystem particles;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            particles.Play();
        }
    }
}

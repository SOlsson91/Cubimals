using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Testing : MonoBehaviour, IPointerClickHandler
{
    public Button button;

    public void OnPointerClick(PointerEventData ped)
    {
        if (ped.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right");
        }
        if (ped.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left");
        }
    }

    void Test()
    {
        Debug.Log("Test");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I hit " + collision.gameObject.tag);
    }
}

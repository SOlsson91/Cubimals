using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    public Button btn;

    private void Start()
    {
        btn.onClick.AddListener(Onclick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I hit " + collision.gameObject.tag);
    }

    public void Onclick()
    {
        Debug.Log("Input Recieved!");
    }
}

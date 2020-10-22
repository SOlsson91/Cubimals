using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    public Button btn;
    public MasterInput userInput;

    private void Start()
    {
        btn.onClick.AddListener(Onclick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        Debug.Log("Button Input Recieved!");
    }
}

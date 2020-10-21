using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateButton : MonoBehaviour
{
    GameObject[] players;
    public GameObject target;

    public float interactiveRadius = 1;

    private bool isActive;

    void Start()
    {
        isActive = false;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        foreach (GameObject player in players)
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) <=
                    interactiveRadius && (Keyboard.current.eKey.isPressed || Gamepad.current.buttonWest.isPressed) && isActive == false)
            {
                isActive = true;
            }
            else if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= 
                    interactiveRadius && (Keyboard.current.eKey.isPressed || Gamepad.current.buttonWest.isPressed))
            {
                isActive = false;
            }
        }
        target.SetActive(isActive);
    }
}

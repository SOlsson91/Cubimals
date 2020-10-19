using UnityEngine;

public class Push : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pushable")
        {
            collision.gameObject.transform.position += player.transform.forward.normalized;
        }
    }
}

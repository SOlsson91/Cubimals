using UnityEngine;

public class SwapAnimal : MonoBehaviour
{
    //NOTE: Only to help out. Might use, not sure
    public enum Animals
    {
        Turtle,
        Bunny,
        Chicken,
        Cow,
        Horse,
    };

    Player player;
    public Animal[] animals;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    public void Swap()
    {
        player.currentAnimalNumber = player.currentAnimalNumber + 1 > animals.Length - 1 ? 0 : player.currentAnimalNumber + 1;
        ChangeAnimal(player.currentAnimalNumber);
        player.UpdateAnimator();
    }

    public void ChangeAnimal(int newAnimal)
    {
        if (newAnimal >= 0 && newAnimal <= animals.Length)
        {
            if (player.currentAnimal != null)
            {
                Destroy(player.currentAnimal.gameObject);
            }
            // Put the animal as a child to player
            player.currentAnimal = Instantiate(animals[newAnimal], transform.position, transform.rotation);
            player.currentAnimal.transform.parent = transform;
        }
    }
}

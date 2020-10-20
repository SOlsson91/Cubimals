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
    [HideInInspector] public Animal currentAnimal;
    [HideInInspector] public int currentAnimalNumber;

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    public void Swap()
    {
        currentAnimalNumber = currentAnimalNumber + 1 > animals.Length - 1 ? 0 : currentAnimalNumber + 1;
        ChangeAnimal(currentAnimalNumber);
    }

    public void ChangeAnimal(int newAnimal)
    {
        if (newAnimal >= 0 && newAnimal <= animals.Length)
        {
            if (currentAnimal != null)
            {
                Destroy(currentAnimal.gameObject);
            }
            // Put the animal as a child to player
            currentAnimal = Instantiate(animals[newAnimal], transform.position, transform.rotation);
            currentAnimal.transform.parent = transform;
        }
    }
}

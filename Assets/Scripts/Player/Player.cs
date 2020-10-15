using UnityEngine;

/*
 * Main player class, will add the other classes functionallity in this one.
 */

public class Player : MonoBehaviour
{
    //NOTE: Only to help out. Might use, not sure
    enum Animals
    {
        Duck,
        Dog
    };
    public Animal[] animals;
    Animal currentAnimal = null;
    public int currentNum  = 0;

    void Start()
    {
        //NOTE: Only to test the functionallity of changing
        ChangeAnimal((int)Animals.Duck);
    }

    void Update()
    {
        //NOTE: Only to test the functionallity of changing
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentNum = currentNum == 0 ? 1 : 0;
            ChangeAnimal(currentNum);
        }
    }

    void ChangeAnimal(int newAnimal)
    {
        if (newAnimal >= 0 && newAnimal <= animals.Length)
        {
            if (currentAnimal != null)
            {
                Destroy(currentAnimal.gameObject);
            }
            // Put the animal as child to player
            currentAnimal = Instantiate(animals[newAnimal], transform.position, transform.rotation);
            currentAnimal.transform.parent = transform;
        }
    }
}

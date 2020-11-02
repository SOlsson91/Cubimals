using UnityEngine;

public class WeightButton : MonoBehaviour
{
    public GameObject target;

    [SerializeField] private GameObject pressurePlate = null;

    private Vector3 defualtPosition = new Vector3();
    private bool isPressured;

    public bool StonePuzzle = false; //Can be removed later, just to help quikc fix

    public bool getActive
    {
        get { return isPressured; }
    }

    private void Start()
    {
        isPressured = false;
        defualtPosition = pressurePlate.transform.position;
    }

    private void FixedUpdate()
    {
        if(pressurePlate != null)
        {
            if(isPressured && pressurePlate.transform.position.y > defualtPosition.y - 0.3f)
            {
                pressurePlate.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            }
            else if(pressurePlate.transform.position.y < defualtPosition.y)
            {
                pressurePlate.transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            }
            else
            {
                pressurePlate.transform.position = defualtPosition;
            }
        }
        else
        {
            Debug.LogError("Not assigned a GameObject to target");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isPressured = true;

        if (StonePuzzle && other.gameObject.tag == "Pushable") //Needs to be reworked, just a quick solution.
        {
            target.SetActive(true);
        }
        target.GetComponent<SendActive>().TriggerUpdate();


    }

    private void OnTriggerExit(Collider other)
    {
        isPressured = false;

            target.GetComponent<SendActive>().TriggerUpdate();

    }
}

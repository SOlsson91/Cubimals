using UnityEngine;
using System.Collections.Generic;

public class blaCam : MonoBehaviour
{
    public float cameraSmoothTime = 0.2f; //Camera smooth time
    public float screenPadding = 2f;   // Space between the top/bottom most target and the screen edge.
    public float minCameraSize = 3f;  // The smallest orthographic size of the camera.

    public int minFOV = 30;


    private Camera mainCamera;                  // Used for referencing the camera.
    private Camera secondaryCamera;
    private float zoomSpeed;               // Reference speed for the smooth damping of the orthographic size.
    private Vector3 cameraMoveVelocity;   // Reference velocity for the smooth damping of the position.
    private Vector3 desPos;              // The position the camera is moving towards.

    private List<Player> animalRef;

    public bool inCave;
    public int yCavePadding;
    public int xCavePadding;

    private void Awake()
    {
        mainCamera = GetComponentInChildren<Camera>();
        secondaryCamera = GetComponentInChildren<Camera>();
        animalRef = GameManager.Instance.players;
    }


    private void FixedUpdate()
    {
        // to avoid null reference
        if (animalRef.Count > 0)
        {
            Move();
            Zoom();
        }
    }


    private void Move()
    {
        
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, desPos, ref cameraMoveVelocity, cameraSmoothTime);

        
    }
    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        // Go through all the targets and add their positions together.
        for (int i = 0; i < animalRef.Count; i++)
        {
            if (!animalRef[i].gameObject.activeSelf)
            {
                mainCamera.fieldOfView = minFOV;
                continue;
            }
            // Add to the average and increment the number of targets in the average.
            averagePos += animalRef[i].transform.position;
            numTargets++;
        }

        // If there are targets divide the sum of the positions by the number of them to find the average.
        if (numTargets > 0)
            averagePos /= numTargets;

        // Keep the same y value.
        //averagePos.y = transform.position.y;
        
        // The desired position is the average position;
        desPos = averagePos;
        if (inCave)
        {  
            Debug.Log("Incave");
            desPos = new Vector3(desPos.x-xCavePadding,desPos.y+yCavePadding,transform.position.z);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (!inCave)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }


    private void Zoom()
    {
        // Find the required size based on the desired position and smoothly transition to that size.
        float requiredSize = FindRequiredSize();

        if (mainCamera.orthographic) 
        { 
            mainCamera.orthographicSize = Mathf.SmoothDamp(mainCamera.orthographicSize, requiredSize, ref zoomSpeed, cameraSmoothTime); 
        } 
        else 
        {
            mainCamera.fieldOfView = Mathf.SmoothDamp(mainCamera.fieldOfView, Mathf.Max(minFOV, screenPadding* Mathf.Abs(Vector3.Distance(animalRef[0].transform.position, animalRef[1].transform.position))), ref zoomSpeed, cameraSmoothTime);
        }
        
    }


    private float FindRequiredSize()
    {
        // Find the position the camera rig is moving towards in its local space.
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desPos);
        // Start the camera's size calculation at zero.
        float size = 0f;
        // Go through all the targets...
        for (int i = 0; i < animalRef.Count; i++)
        {
            // if they aren't active continue on to the next target. Doesnt Work as it should needs to be refined
            if (!animalRef[i].gameObject.activeSelf)
            {
                mainCamera.fieldOfView = minFOV;
                continue;
            }

            // Otherwise, find the position of the target in the camera's local space.
            Vector3 targetLocalPos = transform.InverseTransformPoint(animalRef[i].transform.position);

                // Find the position of the target from the desired position of the camera's local space.
                Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

                // Choose the largest out of the current size and the distance of the tank 'up' or 'down' from the camera.
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

                // Choose the largest out of the current size and the calculated size based on the tank being to the left or right of the camera.
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / mainCamera.aspect);
            
        }

        // Add the edge buffer to the size.
        size += screenPadding;

        // Make sure the camera's size isn't below the minimum.
        size = Mathf.Max(size, minCameraSize);

        return size;
    }
    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        // Set the camera's position to the desired position without damping.
        transform.position = desPos;

        // Find and set the required size of the camera.
        if (mainCamera.orthographic)
        {
            mainCamera.orthographicSize = FindRequiredSize();
        }
        else 
        { 
            mainCamera.fieldOfView = Mathf.Max(minFOV, screenPadding*Mathf.Abs(Vector3.Distance(animalRef[0].transform.position, animalRef[1].transform.position))); 
        } 
   
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in cave");
        if (other.gameObject.name =="Player") { Debug.Log("Player: "); }
    }


}

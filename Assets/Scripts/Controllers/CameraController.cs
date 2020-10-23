using UnityEngine;
/*
 * Following the player with a small smoothing/dampening on the camera
 * Important to change project settings to run SpawnPlayer before CameraController
 */

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 offset;
    Vector3 cameraPosition;
    public Vector3 smoothness = new Vector3(3, 1, 3);

    void Start()
    {
        try
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        catch
        {
            Debug.LogWarning("[CameraController] Cannot find Player");
            Debug.LogWarning("Have you changed the project settings to have SpawnPlayer before CameraController?");
            target = null;
            return;
        }
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // If Player cannot be found retur;
        if (target == null)
            return;

        cameraPosition = target.position + offset;
        Vector3 position = Vector3.zero;
        position.x = Mathf.Lerp(transform.position.x, cameraPosition.x, smoothness.x * Time.fixedDeltaTime);
        position.y = Mathf.Lerp(transform.position.y, cameraPosition.y, smoothness.y * Time.fixedDeltaTime);
        position.z = Mathf.Lerp(transform.position.z, cameraPosition.z, smoothness.z * Time.fixedDeltaTime);
        transform.position = position;
    }
}

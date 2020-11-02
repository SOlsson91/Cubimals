using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public GameObject target;

    public ParticleSystem particles = null;

    public bool isActive = false;
    public bool playParticle = false;

    void Start()
    {
        if (target != null)
        {
            target.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("[ActivateButton]: Missing gameobject");
        }
    }

    public void ActivateTarget()
    {
        if (target == null)
        {
            Debug.LogWarning("[ActivateButton] Target is null");
            return;
        }
        isActive = !isActive;
        target.SetActive(isActive);

        if(playParticle)
        {
            //particles.Play();
            Instantiate(particles, target.transform);
        }
    }
}

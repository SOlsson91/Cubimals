using UnityEngine;

public class Dash : Ability
{
    public float dashSpeed = 1000;
    public float dashTime = 0.2f;
    public float cooldownValue = 3;

    float timeToNextDash = 0;
    float timeDashing = 0;
    bool dashing = false;
    Rigidbody parentRigidbody;

    void Start()
    {
        parentRigidbody = GetComponentInParent<Rigidbody>();
    }

    public override void DoAbility()
    {
        if (!dashing && Time.time >= timeToNextDash)
        {
            dashing = true;
            timeToNextDash = Time.time + cooldownValue;
            timeDashing = Time.time + dashTime;
        }
    }

    private void FixedUpdate()
    {
        if (dashing == true)
        {
            if (Time.time >= timeDashing)
            {
                dashing = false;
                parentRigidbody.velocity = Vector3.zero;
                return;
            }
            parentRigidbody.velocity = gameObject.transform.forward * dashSpeed * Time.deltaTime;
        }
    }
}

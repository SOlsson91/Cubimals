using UnityEngine;

public abstract class AnimBaseState
{
    public abstract void EnterState(AnimStateCtrl animCtrl);

    public abstract void Update(AnimStateCtrl animCtrl);

    public abstract void OnCollisionEnter(AnimStateCtrl animCtrl);
}

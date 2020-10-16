using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimJumpState : AnimBaseState
{
    public override void EnterState(AnimStateCtrl animCtrl)
    {
        Debug.Log("Jump state entered");
        
    }

    public override void OnCollisionEnter(AnimStateCtrl animCtrl)
    {
        animCtrl.TransitionToState(animCtrl.idleState);
    }

    public override void Update(AnimStateCtrl animCtrl)
    {
    }
}

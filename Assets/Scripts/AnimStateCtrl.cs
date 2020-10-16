using UnityEngine;

public class AnimStateCtrl : MonoBehaviour
{
    #region
    [HideInInspector] public Animator animalAnim;
    [HideInInspector] public AnimalMove animalMove;
    AnimBaseState currentState;
    #endregion

    public AnimBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly AnimdleState idleState = new AnimdleState();
    public readonly AnimWalkingState walkingState = new AnimWalkingState();
    public readonly AnimJumpState jumpState = new AnimJumpState();

    void Awake()
    {
        animalAnim = GetComponent<Animator>();
        animalMove = GetComponent<AnimalMove>();
    }
    void Start()
    {
        TransitionToState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this);
    }

    public void TransitionToState(AnimBaseState state) 
    {
        currentState = state;
        CurrentState.EnterState(this);
    }
}

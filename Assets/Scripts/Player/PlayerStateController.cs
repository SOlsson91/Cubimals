using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    #region
    [HideInInspector] public Animator animator;
    public PlayerMove move;
    Player player;
    PlayerBaseState currentState;
    #endregion

    public PlayerBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly PlayerIdleState idleState = new PlayerIdleState();
    public readonly PlayerWalkingState walkingState = new PlayerWalkingState();
    public readonly PlayerJumpState jumpState = new PlayerJumpState();

    void Awake()
    {
        player = GetComponent<Player>();
        move = GetComponent<PlayerMove>();
    }
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        TransitionToState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Fix animator when switching animal
        if (animator == null)
            UpdateAnimator();
        else
            currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this);
    }

    public void TransitionToState(PlayerBaseState state) 
    {
        currentState = state;
        CurrentState.EnterState(this);
    }

    public void UpdateAnimator()
    {
        animator = player.animator;
    }
}

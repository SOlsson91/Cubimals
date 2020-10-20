using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    #region
    [HideInInspector] public PlayerMove move;
    [HideInInspector] public Player player;
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
        TransitionToState(idleState);
    }

    void Update()
    {
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
}

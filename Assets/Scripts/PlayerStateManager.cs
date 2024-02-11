using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public GameObject Player;
    public PlayerBaseState activeState;
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();

    private void Start()
    {
        activeState = idleState;
        activeState.Enter(this);
    }

    private void Update()
    {
        if (activeState != null)
        {
            activeState.Update();
        }
    }

    public void SwitchState(PlayerBaseState baseState)
    {
        baseState.Enter(this);
        activeState = baseState;
    }
}

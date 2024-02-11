using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    
    public override void Enter(PlayerStateManager playerStateManager)
    {
        Debug.Log("Entered in idle state");
        this.StateManager = playerStateManager;
        this.Player = playerStateManager.Player;
    }

    public override void Exit(PlayerStateManager playerStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 || horizontal < 0)
        {
            StateManager.SwitchState(StateManager.walkState);
        }
    }

}

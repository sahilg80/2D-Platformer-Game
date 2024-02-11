using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public GameObject Player { get; set; }
    public Animator PlayerAnimator { get; set; }
    public PlayerStateManager StateManager { get; set; }
    public Collider2D PlayerCollider { get; set; }
    public abstract void Enter(PlayerStateManager playerStateManager);
    public abstract void Update();
    public abstract void Exit(PlayerStateManager playerStateManager);
}

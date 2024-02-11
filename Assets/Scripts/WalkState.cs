using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerBaseState
{
    private float speed;
    private int animationSpeed;
    public override void Enter(PlayerStateManager playerStateManager)
    {
        Debug.Log("Entered in walk state");
        this.StateManager = playerStateManager;
        this.Player = playerStateManager.Player;
        this.PlayerCollider = playerStateManager.Player.GetComponent<BoxCollider2D>();
        this.PlayerAnimator = playerStateManager.Player.GetComponent<Animator>();
        animationSpeed = Animator.StringToHash("Speed");
        speed = 7f;
    }

    public override void Exit(PlayerStateManager playerStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        ControlHorizontalMovement();
    }

    private void ControlHorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (PlayerAnimator != null)
        {
            if (horizontal == 0)
            { 
                StateManager.SwitchState(StateManager.idleState); 
                return; 
            }
            if (IsGrounded())
            {
                PlayerAnimator.SetFloat(animationSpeed, Mathf.Abs(horizontal));
            }
            else
            {
                PlayerAnimator.SetFloat(animationSpeed, 0);
            }

            float scaleX = Player.transform.localScale.x;
            if (horizontal < 0)
            {
                scaleX = -1 * Mathf.Abs(scaleX);
            }
            else
            {
                scaleX = Mathf.Abs(scaleX);
            }
            Player.transform.localScale = new Vector3(scaleX, Player.transform.localScale.y, Player.transform.localScale.z);
            TranslateCharacterHorizontal(horizontal);
        }
    }

    private void TranslateCharacterHorizontal(float horizontal)
    {
        Vector3 position = Player.transform.position;
        position.x += horizontal * Time.deltaTime * speed;
        Player.transform.position = position;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(PlayerCollider.bounds.center, PlayerCollider.bounds.size, 0, Vector2.down, 0.03f, LayerMask.NameToLayer("Platform"));
    }

}

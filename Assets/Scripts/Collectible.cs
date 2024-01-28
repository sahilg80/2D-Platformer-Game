using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (collision != null && playerController != null)
        {
            playerController.GetCollectible(10);
            animator.SetTrigger("IsCollected");
            Destroy(gameObject,3f);
        }
    }
}

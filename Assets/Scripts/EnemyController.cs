using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;
    [SerializeField]
    private GameObject pointA;
    [SerializeField]
    private GameObject pointB;
    [SerializeField]
    private float velocity;
    public Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator.SetBool("IsRunning", true);
        targetTransform = pointB.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_Rigidbody.velocity = new Vector2(velocity, 0);

        if(targetTransform.localPosition.x < transform.localPosition.x && targetTransform == pointB.transform)
        {
            m_Rigidbody.velocity = Vector2.zero;
            Flip(false);
            velocity = -velocity;
            targetTransform = pointA.transform;
        }
        else if (targetTransform.localPosition.x > transform.localPosition.x && targetTransform == pointA.transform)
        {
            m_Rigidbody.velocity = Vector2.zero;
            Flip(true);
            velocity = -velocity;
            targetTransform = pointB.transform;
        }
    }

    private void Flip(bool flip)
    {
        GetComponent<SpriteRenderer>().flipX = flip;
    }


    private void OnCollisionEnter2D1(Collision2D collision)
    {
        Debug.Log("Player died game over");
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (collision != null && playerController != null)
        {
            
            SceneManager.LoadScene("MainScene");
        }
    }
}

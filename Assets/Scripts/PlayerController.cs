using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator m_Animator;
    [SerializeField]
    ScoreController m_ScoreController;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    //[SerializeField]
    //private GameObject m_Player;
    private Rigidbody2D m_Rigidbody2D;
    private Collider2D m_Collider;
    [SerializeField]
    private LayerMask jumpableLayers;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlHorizontalMovement();
        Crouch();
        ControlJump();
    }

    private void ControlJump()
    {
        if (m_Animator != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            TranslateCharacterVertical();
            m_Animator.SetTrigger("Jump");
        }
    }

    private void ControlHorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (m_Animator != null)
        {
            if (horizontal == 0) { return; }
            m_Animator.SetFloat("Speed", Mathf.Abs(horizontal));
            float scaleX = transform.localScale.x;
            if (horizontal < 0)
            {
                scaleX = -1 * Mathf.Abs(scaleX);
            }
            else
            {
                scaleX = Mathf.Abs(scaleX);
            }
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            TranslateCharacterHorizontal(horizontal);
        }
    }

    private void Crouch()
    {
        if (m_Animator != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                m_Animator.SetBool("IsCrouch", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
            {
                m_Animator.SetBool("IsCrouch", false);
            }
        }
    }

    private void TranslateCharacterHorizontal(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * Time.deltaTime * speed;
        transform.position = position;
    }

    private void TranslateCharacterVertical()
    {
        m_Rigidbody2D.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(m_Collider.bounds.center, m_Collider.bounds.size, 0, Vector2.down, 0.01f, jumpableLayers);
    }

    public void GetCollectible(int value)
    {
        score += value;
        m_ScoreController.SetScoreInUI(score);
    }

}

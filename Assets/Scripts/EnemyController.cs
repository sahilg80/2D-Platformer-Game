
using UnityEngine;

public class EnemyController : AutomaticMovingController
{
    private Animator m_Animator;
    ////private Rigidbody2D m_Rigidbody;
    //[SerializeField]
    //private GameObject pointA;
    //[SerializeField]
    //private GameObject pointB;
    //[SerializeField]
    //private float velocity;
    [SerializeField]
    private HealthController healthController;
    //Transform targetTransform;

    // Start is called before the first frame update
    protected override void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("IsRunning", true);
        base.Start();
        //m_Animator = GetComponent<Animator>();
        //m_Animator.SetBool("IsRunning", true);
        //targetTransform = pointB.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //transform.position = transform.position + new Vector3(velocity*Time.deltaTime,0,0);

        //if(targetTransform.localPosition.x < transform.localPosition.x && targetTransform == pointB.transform)
        //{
        //    Flip(false);
        //    velocity = -velocity;
        //    targetTransform = pointA.transform;
        //}
        //else if (targetTransform.localPosition.x > transform.localPosition.x && targetTransform == pointA.transform)
        //{
        //    Flip(true);
        //    velocity = -velocity;
        //    targetTransform = pointB.transform;
        //}
    }

    //private void Flip(bool flip)
    //{
    //    GetComponent<SpriteRenderer>().flipX = flip;
    //}

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (collision != null && playerController != null)
        {

            healthController.PlayerDamage(1);
            if (healthController.currentHealth <= 0)
            {
                playerController.Died();
                this.enabled = false;
                m_Animator.enabled = false;
            }
            else
            {
                playerController.Attack();
            }
        }
    }

}

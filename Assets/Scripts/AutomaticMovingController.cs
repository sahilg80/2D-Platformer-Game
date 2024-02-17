using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutomaticMovingController : MonoBehaviour
{
    //private Rigidbody2D m_Rigidbody;
    [SerializeField]
    private GameObject pointA;
    [SerializeField]
    private GameObject pointB;
    [SerializeField]
    private float velocity;
    Transform targetTransform;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        targetTransform = pointB.transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = transform.position + new Vector3(velocity * Time.deltaTime, 0, 0);

        if (targetTransform.localPosition.x < transform.localPosition.x && targetTransform == pointB.transform)
        {
            Flip(false);
            velocity = -velocity;
            targetTransform = pointA.transform;
        }
        else if (targetTransform.localPosition.x > transform.localPosition.x && targetTransform == pointA.transform)
        {
            Flip(true);
            velocity = -velocity;
            targetTransform = pointB.transform;
        }
    }

    private void Flip(bool flip)
    {
        GetComponent<SpriteRenderer>().flipX = flip;
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);

}

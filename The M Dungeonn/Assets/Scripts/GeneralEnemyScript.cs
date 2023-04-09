using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemyScript : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Transform CurrentPoint;

    public float speed;
    public BoxCollider2D boxCollider;
    public EdgeCollider2D edgeCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentPoint = PointA.transform;
    }
    private void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if (CurrentPoint == PointA.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointB.transform)
        {
            flip();
            CurrentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointA.transform)
        {
            flip();
            CurrentPoint = PointB.transform;
        }
    }
    private void flip()
    {
        Vector3 localsclae = transform.localScale;
        localsclae.x *= -1;
        transform.localScale = localsclae;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}




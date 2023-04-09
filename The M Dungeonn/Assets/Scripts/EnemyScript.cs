using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentPointIndex = 0;
    [SerializeField] private float speed = 2f;
    //public BoxCollider2D boxCollider;
    public EdgeCollider2D edgeCollider;
    Player_life player_Life;
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(wayPoints[currentPointIndex].transform.position, transform.position) < .1f)
        {
            currentPointIndex++;
            flip();
            if (currentPointIndex >= wayPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPointIndex].transform.position, Time.deltaTime * speed);
    }
    private void flip()
    {
        Vector3 localsclae = transform.localScale;
        localsclae.x *= -1;
        transform.localScale = localsclae;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherCollider==edgeCollider)
        {
            gameObject.SetActive(false);
        }
    }
}

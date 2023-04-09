using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentPointIndex = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(wayPoints[currentPointIndex].transform.position, transform.position) < .1f)
        {
            currentPointIndex++;
            if(currentPointIndex >= wayPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPointIndex].transform.position, Time.deltaTime * speed);
    }
}

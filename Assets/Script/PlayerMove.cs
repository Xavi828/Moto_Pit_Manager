using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 40f;
    public Transform[] trackPoint;
    public float moveSpeed = 40f;
    public float changeTrargetPoint = 0.4f;
    

    int currentPointTarget = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveToPoint())
        {
            currentPointTarget = NextPointTarget();
        }
    }

    private bool MoveToPoint ()
    {
        Vector3 distanceVector = trackPoint[currentPointTarget].position - transform.position;
        if (distanceVector.magnitude < changeTrargetPoint)
        {
            return true;
        }

        Vector3 velocityVector = distanceVector.normalized;
        transform.position += velocityVector * playerSpeed * Time.deltaTime;

        return false;

    }

    private int NextPointTarget()
    {
        currentPointTarget++;
        if (currentPointTarget >= trackPoint.Length)
        {
            currentPointTarget = 0;
        }

        return currentPointTarget;

    }
}

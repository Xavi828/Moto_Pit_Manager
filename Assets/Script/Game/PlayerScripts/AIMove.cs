using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    public float aiSpeed;
    public float aiPitBoxVelocity;
    public float aiTrackVelocity;
    public Transform[] aiTrackPoint;
    public Transform[] aiPitStopLinePoint;
    public Transform[] aiPitStopEntryPoint;
    public Transform[] aiPitStopExitPoint;
    public bool inPitStop = false;

    private float changeTrargetPoint = 0.4f;
    private float distanceNextPoint;
    private bool confirmedPitStop = false;
    private string pitsPosition;
    private float pitTimeWait;
    private float tireWearAI;
    private float fuelAmountAI;
    private Vector3 distanceVector;
    private Vector3 velocityVector;


    public AIBrain aiBrain;
    private int currentPointTarget = 0;

    void Start()
    {
        tireWearAI = 1;
        fuelAmountAI = 1;
        aiSpeed = aiTrackVelocity * tireWearAI;
        pitsPosition = "onTrack";
        inPitStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveToPoint())
        {
            currentPointTarget = NextPointTarget();
        }
        if (!inPitStop)
        {
            aiSpeed = aiTrackVelocity * tireWearAI;
        }
        else
        {
            aiSpeed = aiPitBoxVelocity;
        }



        tireWearAI = aiBrain.tireWearNumAI;
        fuelAmountAI = aiBrain.fuelAmountNum;
    }

    public void PitStopIn()
    {
        confirmedPitStop = true;
    }

    public void PitStopOut()
    {
        confirmedPitStop = false;
    }

    private int NextPointTarget()
    {
        currentPointTarget++;
        if (currentPointTarget >= aiPitStopEntryPoint.Length && pitsPosition == "entry")
        {
            pitsPosition = "line";
            currentPointTarget = 0;
            inPitStop = true;
        }
        if (currentPointTarget >= aiPitStopLinePoint.Length && pitsPosition == "line")
        {
            pitsPosition = "exit";
            currentPointTarget = 0;
        }
        if (currentPointTarget == 4 && pitsPosition == "line")
        {
            StartCoroutine("WaitPitStop");
        }
        if (currentPointTarget >= aiPitStopExitPoint.Length && pitsPosition == "exit")
        {
            pitsPosition = "onTrack";
            currentPointTarget = 1;
            inPitStop = false;
        }
        if (currentPointTarget >= aiTrackPoint.Length && pitsPosition == "onTrack")
        {
            if (confirmedPitStop == true)
            {
                pitsPosition = "entry";
                inPitStop = true;
            }
            else
            {
                pitsPosition = "onTrack";
                inPitStop = false;
            }
            currentPointTarget = 0;
        }
        else
        {

        }

        return currentPointTarget;


    }

    private bool MoveToPoint()
    {
        switch (pitsPosition)
        {

            case "entry":
                distanceVector = aiPitStopEntryPoint[currentPointTarget].position - transform.position;
                break;

            case "line":
                distanceVector = aiPitStopLinePoint[currentPointTarget].position - transform.position;
                break;

            case "exit":
                distanceVector = aiPitStopExitPoint[currentPointTarget].position - transform.position;
                break;

            case "onTrack":
                distanceVector = aiTrackPoint[currentPointTarget].position - transform.position;
                break;

            default:
                distanceVector = aiTrackPoint[currentPointTarget].position - transform.position;
                break;
        }

        if (distanceVector.magnitude < changeTrargetPoint)
        {
            return true;
        }

        velocityVector = distanceVector.normalized;
        transform.position += velocityVector * aiSpeed * Time.deltaTime;
        return false;
    }

    IEnumerator WaitPitStop()
    {
        aiSpeed = 0;
        pitTimeWait = aiBrain.PitsTimer();
        yield return new WaitForSeconds(pitTimeWait);
        aiSpeed = 15;
        aiBrain.NewTire();
        aiBrain.ChangeFuelAmount();
    }
}

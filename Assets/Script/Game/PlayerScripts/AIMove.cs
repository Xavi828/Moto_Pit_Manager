using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    private float aiSpeed;
    private Vector3 distanceVector;
    private float changeTrargetPoint = 0.4f;
    private float distanceNextPoint;
    private bool confirmedPitStop = false;
    private string pitsPosition;
    private float pitTimeWait;
    private float tireWear;
    private float fuelAmount;
    private int currentPointTarget = 0;

    public float pitBoxVelocity;
    public float trackVelocity;
    public bool inPitStop = false;

    public Transform[] trackPoint;
    public Transform[] pitStopLinePoint;
    public Transform[] pitStopEntryPoint;
    public Transform[] pitStopExitPoint;

    public AIBrain aiBrain;

    void Start()
    {
        tireWear = 1;
        fuelAmount = 1;
        pitsPosition = "onTrack";
    }

    void Update()
    {
        if (MoveToPoint())
        {
            currentPointTarget = NextPointTarget();
        }

        if (pitsPosition == "exit")
        {
            aiSpeed = pitBoxVelocity;
        }

        if (!inPitStop)
        {
            aiSpeed = trackVelocity * tireWear * fuelAmount;
        }

        tireWear = aiBrain.tireWearNum;
        fuelAmount = aiBrain.fuelAmountNum;
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
        if (currentPointTarget >= pitStopEntryPoint.Length && pitsPosition == "entry")
        {
            pitsPosition = "line";
            currentPointTarget = 0;
            inPitStop = true;
        }
        if (currentPointTarget >= pitStopLinePoint.Length && pitsPosition == "line")
        {
            pitsPosition = "exit";
            currentPointTarget = 0;
        }
        if (currentPointTarget == 4 && pitsPosition == "line")
        {
            StartCoroutine("WaitPitStop");
        }
        if (currentPointTarget >= pitStopExitPoint.Length && pitsPosition == "exit")
        {
            pitsPosition = "onTrack";
            currentPointTarget = 1;
            inPitStop = false;
        }
        if (currentPointTarget >= trackPoint.Length && pitsPosition == "onTrack")
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
                distanceVector = pitStopEntryPoint[currentPointTarget].position - transform.position;
                break;

            case "line":
                distanceVector = pitStopLinePoint[currentPointTarget].position - transform.position;
                break;

            case "exit":
                distanceVector = pitStopExitPoint[currentPointTarget].position - transform.position;
                break;

            case "onTrack":
                distanceVector = trackPoint[currentPointTarget].position - transform.position;
                break;

            default:
                distanceVector = trackPoint[currentPointTarget].position - transform.position;
                break;
        }

        if (distanceVector.magnitude < changeTrargetPoint)
        {
            return true;
        }

        transform.position += distanceVector.normalized * aiSpeed * Time.deltaTime;
        return false;
    }

    IEnumerator WaitPitStop()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        aiSpeed = 0;
        pitTimeWait = aiBrain.PitsTimer();
        yield return new WaitForSeconds(pitTimeWait);
        aiSpeed = 15;
        aiBrain.NewTire();
        aiBrain.ChangeFuelAmount();
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}

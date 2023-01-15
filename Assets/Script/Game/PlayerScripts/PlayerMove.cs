using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed;
    public float pitBoxVelocity;
    public float trackVelocity;
    public Transform[] trackPoint;
    public Transform[] pitStopLinePoint;
    public Transform[] pitStopEntryPoint;
    public Transform[] pitStopExitPoint;
    public bool inPitStop = false;

    private float changeTrargetPoint = 0.4f;
    private float distanceNextPoint;
    private bool confirmedPitStop = false;
    public GameObject InTheBox;
    private string pitsPosition;
    private float pitsTimer;
    private float pitTimeWait;
    private float tireWear;
    private float fuelAmount;
    private Vector3 distanceVector;
    private Vector3 velocityVector;


    public PlayerInterface playerInterface;
    private int currentPointTarget = 0;

    void Start()
    {
        InTheBox.SetActive(false);
        Time.timeScale = 1;
        tireWear = 1;
        fuelAmount = 1;
        playerSpeed = trackVelocity * tireWear;
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

        if (pitsPosition == "exit")
        {
            playerSpeed = pitBoxVelocity;
        }

        if (!inPitStop)
        {
            playerSpeed = trackVelocity * tireWear * fuelAmount;
        }

        tireWear = playerInterface.tireWearNum;
        fuelAmount = playerInterface.fuelAmountNum;
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
            InTheBox.SetActive(false);
            playerInterface.PitStopButton();
            inPitStop = false;
        }
        if (currentPointTarget >= trackPoint.Length && pitsPosition == "onTrack")
        {
            if (confirmedPitStop == true)
            {
                pitsPosition = "entry";
                InTheBox.SetActive(true);
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

        velocityVector = distanceVector.normalized;
        transform.position += velocityVector * playerSpeed * Time.deltaTime;
        return false;
    }

    IEnumerator WaitPitStop()
    {
        playerSpeed = 0;
        pitTimeWait = playerInterface.PitsTimer();
        yield return new WaitForSeconds(pitTimeWait);
        playerSpeed = 15;
        playerInterface.NewTire();
        playerInterface.ChangeFuelAmount();
    }
}

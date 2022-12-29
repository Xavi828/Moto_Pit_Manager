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
    public float changeTrargetPoint = 0.4f;
    public bool confirmedPitStop = false;
    public bool inPitStop = false;
    public GameObject InTheBox;
    public string pitsPosition;
    public int pitsPositionNum = 0;
    public float pitsTimer;
    public float pitTimeWait;
    public float tireWear;
    public float fuelAmount;
    public Vector3 distanceVector;
    public Vector3 velocityVector;

    public PlayerInterface playerInterface;
    int currentPointTarget = 0;

    void Start()
    {
        InTheBox.SetActive(false);
        Time.timeScale = 1;
        tireWear = 1;
        fuelAmount = 1;
        playerSpeed = trackVelocity * tireWear * fuelAmount;
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

        tireWear = playerInterface.tireWearNum;
        fuelAmount = 1 + playerInterface.fuelAmountNum;
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
            playerSpeed = pitBoxVelocity;
            currentPointTarget = 0;
            inPitStop = true;
        }
        if (currentPointTarget >= pitStopLinePoint.Length && pitsPosition == "line")
        {
            pitsPosition = "exit";
            playerSpeed = pitBoxVelocity;
            currentPointTarget = 0;
        }
        if (currentPointTarget == 4 && pitsPosition == "line")
        {
            StartCoroutine("WaitPitStop");
        }
        if (currentPointTarget >= pitStopExitPoint.Length && pitsPosition == "exit")
        {
            pitsPosition = "onTrack";
            playerSpeed = trackVelocity * tireWear * fuelAmount;
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
                playerSpeed = pitBoxVelocity;
                InTheBox.SetActive(true);
                inPitStop = true;
            }
            else
            {
                pitsPosition = "onTrack";
                playerSpeed = trackVelocity * tireWear * fuelAmount;
                inPitStop = false;
            }
            currentPointTarget = 0;    
        }
        else
        {
            Debug.Log("Nothing");
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
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        playerSpeed = 0;
        pitTimeWait = playerInterface.PitsTimer();
        yield return new WaitForSeconds(pitTimeWait);
        playerSpeed = 15;
        playerInterface.NewTire();
        playerInterface.ChangeFuelAmount();
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}

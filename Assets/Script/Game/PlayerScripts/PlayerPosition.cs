using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public int playerNum;
    public float playerPosition;
    public int playerLap;
    public int playerCheckPoint;
    public int nextPoint;
    public float playerDistance;
    //private bool firstLap;

    public Transform[] chekPoint;

    public Vector3 distanceVector;
    public PlayerMove playerMove;
    public AIMove aIMove;


    void Start ()
    {
        if (playerNum == 21)
        {
            playerNum = PlayerPrefs.GetInt("PlayerNum");


        }
    }

    void Update()
    {
        if (nextPoint >= 10)
        {
            nextPoint = 0;
        }
        PlayersPositionMesure();
    }

    private void OnTriggerEnter(Collider other)
    {
        int.TryParse(other.gameObject.name, out playerCheckPoint);
        
        if (playerCheckPoint == 0)
        {
            playerLap = playerLap + 1;
        }

    }

    public void PlayersPositionMesure()
    {
        distanceVector = chekPoint[nextPoint].position - transform.position;
        playerDistance = 999 - distanceVector.magnitude;
        playerPosition = playerLap * 100000 + playerCheckPoint * 1000 + playerDistance;
        nextPoint = playerCheckPoint + 1;

    }


}

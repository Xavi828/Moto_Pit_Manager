using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public float playerPosition;
    public int playerLap;
    public int playerCheckPoint;
    public int nextPoint;
    public float playerDistance;
    public bool firstLap;

    public Transform[] chekPoint;

    public Vector3 distanceVector;
    public PlayerMove playerMove;
    public DataBase dataBase;

    void Start()
    {
        firstLap=true;
    }

    void Update()
    {
        PlayersPositionMesure();
    }

    private void OnTriggerEnter(Collider other)
    {
        int.TryParse(other.gameObject.name, out playerCheckPoint);
        Debug.Log("checkPoint Reached" + playerCheckPoint);

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

        if (nextPoint >= 9)
        {
            nextPoint = 0;
        }
        else
        {
            nextPoint = playerCheckPoint + 1;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public float playerPosition;
    public int playerLap;
    public int playerCheckPoint;
    public float playerDistance;

    private void OnTriggerEnter(Collider other)
    {
        int.TryParse(other.gameObject.name, out playerCheckPoint);
    }

    public float PlayersPositionMesure()
    {
        playerPosition = playerPosition + playerLap * 100000 + playerCheckPoint * 1000 + playerDistance;

        if (playerCheckPoint == 1)
        {
            playerLap = playerLap + 1;
            return playerPosition;
        }
        else
        {
            return playerPosition;
        }
    }
}

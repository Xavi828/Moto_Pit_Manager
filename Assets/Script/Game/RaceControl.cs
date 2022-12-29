using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceControl : MonoBehaviour
{
    public DataBase dataBase;
    public PlayerPosition[] playerPosition;
    public float[] playersPositions;
    public int e;


    void Update()
    {
        for (int i = 0; i == playerPosition.Length; i++)
        {
            //playersPositions[i] = playerPositions[i].PlayersPositionMesure();
        }
        PlayersPositionOrder();
    }


    public void PlayersPositionOrder()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingStart : MonoBehaviour
{

    public Transform[] iaPlayers;
    public Transform humanPlayer;
    public GameObject[] destroyGameObjectPlayer;

    private Transform destroyPlayer;

    private int playerNum;

    void Start()
    {
        playerNum = PlayerPrefs.GetInt("PlayerNum");

        destroyPlayer = iaPlayers[playerNum];

        humanPlayer.position = destroyPlayer.position;

        Destroy(destroyGameObjectPlayer[playerNum]);
    }
}

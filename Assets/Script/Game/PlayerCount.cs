using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCount : MonoBehaviour
{
    public GameObject playersContainer;
    private int playersAmount;

    void Start()
    {
        playersAmount = playersContainer.transform.childCount;
        PlayerPrefs.SetInt("AmountOfPlayers", playersAmount);
    }
}

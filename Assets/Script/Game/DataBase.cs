using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public SpriteRenderer[] iaPlayer;
    public int playerNum;
    public string[] businessNames;
    public string businessPlayerName;

    public void Start()
    {   
        //Get Player Prefs
        playerNum = PlayerPrefs.GetInt("PlayerSelected");
        businessPlayerName = PlayerPrefs.GetString("businessName");
        //Change Ia name yo Player Name
        businessNames[playerNum] = businessPlayerName;
        Debug.Log(businessNames[playerNum]);
    }
}

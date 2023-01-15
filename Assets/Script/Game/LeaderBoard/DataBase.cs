using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public string[] businessNames;
    public string[] iaNames;

    private int playerNum;
    private string playerName;
    private string businessName;

    void Start()
    {
        //Get the player PlayerPrefs Name and number
        playerNum = PlayerPrefs.GetInt("PlayerColorSelected");
        playerName = PlayerPrefs.GetString("playerName");
        businessName = PlayerPrefs.GetString("businessName");

        //Set the AI and the player PlayerPrefs Names
        for (int i = 0; i < businessNames.Length; i++)
        {
            PlayerPrefs.SetString("BusinessDataBase" + i, businessNames[i]);
        }
        for (int i = 0; i < iaNames.Length; i++)
        {
            PlayerPrefs.SetString("NamesDataBase" + i, iaNames[i]);
        }
        PlayerPrefs.SetString("BusinessDataBase" + playerNum, businessName);
        PlayerPrefs.SetString("NamesDataBase" + playerNum, playerName);
        PlayerPrefs.SetInt("PlayerNum", playerNum);
    }
}

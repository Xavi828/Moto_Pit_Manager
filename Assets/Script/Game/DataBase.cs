using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public SpriteRenderer[] iaPlayer;
    public Text[] leaderbordWriter;
    public string[] businessNames;
    public string[] iaNames;

    public Color textColor;

    private int playerNum;
    private bool leaderBoard = true;
    private string playerName;
    private string businessName;
    private string leaderboardName;


    void Start()
    {
        for (int i = 0; i < businessNames.Length; i++)
        {
            PlayerPrefs.SetString("PlayerDataBase" + i, iaNames[i] + " " + businessNames[i]);
        }
        playerNum = PlayerPrefs.GetInt("PlayerColorSelected");
        playerName = PlayerPrefs.GetString("playerName");
        businessName = PlayerPrefs.GetString("businessName");
        PlayerPrefs.SetString("PlayerDataBase" + playerNum, playerName + " " + businessName);

        textColor = new Color( 1, 1, 1, 1);
        leaderbordWriter[playerNum].GetComponent<Text>().color = textColor;

        LeaderBoard();
    }

    public void LeaderBoard()
    {
        if (leaderBoard)
        {
            LeaderBoardBusiness();
            leaderBoard = false;
        }
        else
        {
            LeaderBoardNames();
            leaderBoard = true;
        }
    }

    public void LeaderBoardNames()
    {
        
        for (int e = 0; e < iaNames.Length; e++)
        {
            leaderbordWriter[e].text = iaNames[e];
        }
        leaderbordWriter[playerNum].text = playerName;
    }

    public void LeaderBoardBusiness()
    {
        for (int e = 0; e < businessNames.Length; e++)
        {
            leaderbordWriter[e].text = businessNames[e];
        }
        leaderbordWriter[playerNum].text = businessName;
    }
}

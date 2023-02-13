using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public Text[] leaderbordWriter;
    public List<string> businessNames = new List<string>();
    public List<string> names = new List<string>();


    public Color playerTextColor = new Color(1, 1, 1, 1);
    public Color aiTextColor = new Color(0, 0, 0, 1);
    private bool leaderBoard = false;
    private int playersPositionNum;
    private int playersAmount;
    private int playerNum;

    void Start()
    {
        playerNum = PlayerPrefs.GetInt("PlayerNum");

        Debug.Log(PlayerPrefs.GetString("BusinessDataBase" + playerNum));

        playersAmount = PlayerPrefs.GetInt("AmountOfPlayers");

        for (int i = 0; i < playersAmount; i++)
        {
            businessNames.Add(PlayerPrefs.GetString("BusinessDataBase" + i));
        }
        for (int i = 0; i < playersAmount; i++)
        {
            names.Add(PlayerPrefs.GetString("NamesDataBase" + i));
        }
        
    }

    void Update()
    {
        GetPlayersPositionList();
    }

    public void LeaderBoard()
    {
        if (leaderBoard)
        {
            leaderBoard = false;
        }
        else
        {
            leaderBoard = true;
        }
    }

    public void GetPlayersPositionList()
    {
        for (int i = 0; i < playersAmount; i++)
        {
            playersPositionNum = PlayerPrefs.GetInt("PlayerPosition" + i);

            if (leaderBoard)
            {
                leaderbordWriter[i].text = businessNames[playersPositionNum];
            }
            else
            {
                leaderbordWriter[i].text = names[playersPositionNum];
            }

            if (playersPositionNum == playerNum)
            {
                leaderbordWriter[i].color = playerTextColor;
            }
            else
            {
                leaderbordWriter[i].color = aiTextColor;
            }
        }
    }
}

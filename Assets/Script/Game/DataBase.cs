using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public PlayerPosition[] playerPosition;
    public Text[] leaderbordWriter;
    public string[] businessNames;
    public string[] iaNames;

    public GameObject CheckPoint1;
    public Color textColor;
    public int playerNum;
    public float[] playerPositionValue;

    private int s;
    private bool leaderBoard = true;
    private string changer;
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

        businessNames[playerNum] = businessName;
        iaNames[playerNum] = playerName;

        CheckPoint1.SetActive(false);

        StartCoroutine("FirstCheckPoint");
        LeaderBoard();
    }

    void Update()
    {
        //OverTake2();
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
    }

    public void LeaderBoardBusiness()
    {
        for (int e = 0; e < businessNames.Length; e++)
        {
            leaderbordWriter[e].text = businessNames[e];
        }
    }

    public void OverTake()
    {
        for (int e = 1; e < playerPosition.Length; e++)
        {
            s = e - 1;
            //playerPositionValue[e] = playerPosition[e].PlayersPositionMesure();

            if (playerPositionValue[s] < playerPositionValue[e])
            {
                if (leaderBoard)
                {
                    leaderbordWriter[s].text = businessNames[e];
                    changer = businessNames[s];
                    businessNames[s] = businessNames[e];
                    businessNames[e] = changer;
                                       
                }
                else
                {
                    leaderbordWriter[s].text = iaNames[e];
                    changer = iaNames[s];
                    iaNames[s] = iaNames[e];
                    iaNames[e] = changer;
                }
            }
        }
    }

    public void OverTake2()
    {
        for (int e = 1; e < playerPosition.Length; e++)
        {
            s = e - 1;
            playerPositionValue[e] = playerPosition[e].playerPosition;
            playerPositionValue[s] = playerPosition[s].playerPosition;

            if (playerPositionValue[s] < playerPositionValue[e])
            {
                if (leaderBoard)
                {
                    leaderbordWriter[s].text = businessNames[e];
                    changer = businessNames[s];
                    businessNames[s] = businessNames[e];
                    businessNames[e] = changer;

                }
                else
                {
                    leaderbordWriter[s].text = iaNames[e];
                    changer = iaNames[s];
                    iaNames[s] = iaNames[e];
                    iaNames[e] = changer;
                }
            }
        }
    }

    IEnumerator FirstCheckPoint()
    {
        yield return new WaitForSeconds(10);
        CheckPoint1.SetActive(true);
    }
}

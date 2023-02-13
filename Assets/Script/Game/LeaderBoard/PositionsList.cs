using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsList : MonoBehaviour
{
    public List<GameObject> bag = new List<GameObject>();
    public List<GameObject> loser = new List<GameObject>();
    public List<GameObject> winer = new List<GameObject>();
    public GameObject playerGameObject;

    int bagPlayersCount1;
    int bagPlayersCount2;
    int loserPlayersCount;
    int winerPlayersCount;
    int playersAmount;
    int playerNum;

    void Start()
    {
        playersAmount = 10;
        playerNum = PlayerPrefs.GetInt("PlayerNum");
        bag.Remove(bag[playerNum]);
        bag.Add(playerGameObject);
        Sort();
    }

    void Update()
    {
        Sort();
        CheckPlayerList();
    }

    public void Sort()
    {
        bagPlayersCount1 = bag.Count;
        
        for (int i = 0; i < bagPlayersCount1; i++)
        {
            bagPlayersCount2 = bag.Count;

            for (int e = 0; e < bagPlayersCount2; e++)
            {
                if (bag.Count > 1)
                {
                    if (bag[0].GetComponent<PlayerPosition>().playerPosition > bag[1].GetComponent<PlayerPosition>().playerPosition)
                    {
                        loser.Add(bag[1]);
                        bag.Remove(bag[1]);
                    }
                    else
                    {
                        loser.Add(bag[0]);
                        bag.Remove(bag[0]);
                    }
                }
                else
                {
                    winer.Add(bag[0]);
                    bag.Remove(bag[0]);

                    loserPlayersCount = loser.Count;

                    for (int a = 0; a < loserPlayersCount; a++)
                    {
                        bag.Add(loser[0]);
                        loser.Remove(loser[0]);
                    }
                }
            }
        }
       
    }

    public void CheckPlayerList()
    {
        winerPlayersCount = winer.Count;

        for (int a = 0; a < playersAmount; a++)
        {
            playerNum = winer[a].GetComponent<PlayerPosition>().playerNum;
            PlayerPrefs.SetInt("PlayerPosition" + a, playerNum);
        }

        for (int i = 0; i < winerPlayersCount; i++)
        {
            for (int e = 0; e < winer.Count; e++)
            {
                bag.Add(winer[e]);
                winer.Remove(winer[e]);
            }
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{

    public GameObject playerGameObject;
    public GameObject aiGameObject;
    public int aiNum;



    void Start()
    {
        if (aiNum == PlayerPrefs.GetInt("PlayerNum"))
        {
            playerGameObject.transform.position = aiGameObject.transform.position;
        }
         
    }
}

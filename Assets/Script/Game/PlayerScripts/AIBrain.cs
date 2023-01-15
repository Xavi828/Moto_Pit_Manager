using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIBrain : MonoBehaviour
{
    private bool selected;
    private bool inBox;
    public float tireWearNumAI;
    public float fuelAmountNum;
    public float fuelAmountFill;
    public float pitsTime;
    private float rearTireSelected;
    private float frontTireSelected;

    public AIMove aiMove;

    void Start()
    {
        tireWearNumAI = 1;
        fuelAmountNum = 1;
        selected = false;
    }

    void Update()
    {
        inBox = aiMove.inPitStop;
        if (!inBox)
        {
            TireManager();
            FuelManager();
        }
        else
        {

        }
    }

    public void PitStopButton()
    {
        if (selected == false)
        {
            selected = true;
            aiMove.PitStopIn();
            PitsPanelManager();
        }
        else
        {
            selected = false;
            aiMove.PitStopOut();
        }

    }

    public void CheckStop()
    {
        selected = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TireManager()
    {
        if (tireWearNumAI > 0)
        {
            tireWearNumAI -= Time.deltaTime * 0.005f;
        }
    }

    public void FuelManager()
    {
        if (fuelAmountNum > 0)
        {
            fuelAmountNum -= Time.deltaTime * 0.005f;
        }
    }

    public void NewTire()
    {
        tireWearNumAI = 1;
    }

    public void PitsPanelManager()
    {
        
    }

    public void TireChangerManager(int a)
    {
        if (a == 1 || a == 2 || a == 3)
        {
            PlayerPrefs.SetInt("FrontTireSelected", a);
            rearTireSelected = 3;
        }
        if (a == 4 || a == 5 || a == 6)
        {
            PlayerPrefs.SetInt("RearTireSelected", a);
            frontTireSelected = 3;
        }
    }


    public float PitsTimer()
    {
        //Ojo aqui abajo
        fuelAmountFill = fuelAmountNum;
        if (fuelAmountFill < 0)
        {
            fuelAmountFill = fuelAmountFill * -1;
        }
        pitsTime = frontTireSelected + rearTireSelected + 6 * fuelAmountFill;
        return pitsTime;
    }

    public void ChangeFuelAmount()
    {

    }
}

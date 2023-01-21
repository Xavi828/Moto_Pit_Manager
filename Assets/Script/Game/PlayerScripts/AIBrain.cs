using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    private bool selected;
    private bool inBox;
    private float fuelAmountFill;
    private float pitsTime;
    private float rearTireSelected;
    private float frontTireSelected;

    public float tireWearNum;
    public float fuelAmountNum;

    public AIMove aiMove;

    void Start()
    {
        tireWearNum = 1;
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

    public void TireManager()
    {
        if (tireWearNum > 0)
        {
            tireWearNum -= Time.deltaTime * 0.005f;
        }
        else
        {
            Retired();
        }
    }

    public void FuelManager()
    {
        if (fuelAmountNum > 0)
        {
            fuelAmountNum -= Time.deltaTime * 0.005f;
        }
        else
        {
            Retired();
        }
    }

    public void NewTire()
    {
        tireWearNum = 1;
    }

    public void Retired()
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
        fuelAmountFill = 1;
        if (fuelAmountFill < 0)
        {
            fuelAmountFill = fuelAmountFill * -1;
        }
        pitsTime = frontTireSelected + rearTireSelected + 6 * fuelAmountFill;
        return pitsTime;
    }

    public void ChangeFuelAmount()
    {
        fuelAmountNum = 1;
    }
}

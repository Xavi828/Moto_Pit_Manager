using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInterface : MonoBehaviour
{
    public GameObject BoxInButton;
    public GameObject BoxOutButton;
    public GameObject ImageTire;
    public GameObject ImageFillFuel;
    public GameObject ImageFuel;
    public GameObject RetiredPanel;
    public GameObject PitsPanel;
    public GameObject RightHud;
    public GameObject OptionsHud;
    public Text pitsTimeWriter;
    private bool selected;
    private bool inBox;
    private bool pitsPanelOpen;
    private Color tireWearColor;
    private Color fuelAmountColor;
    public float tireWearNum;
    public float fuelAmountNum;
    public float fuelAmountFill;
    public float pitsTime;
    private float rearTireSelected;
    private float frontTireSelected;
    private float tireColorR;
    private float tireColorG;
    private float fuelColorG;
    private float colorA = 1f;
    private float colorB = 0f;
    
    public float playerPosition;
    public PlayerPosition playerPositionScript;

    [SerializeField] Slider tireWearSlider;
    [SerializeField] Slider fuelAmountSlider;
    [SerializeField] Slider fuelFillerSlider;

    public PlayerMove playerMove;

    void Start()
    {
        BoxInButton.SetActive(false);
        BoxOutButton.SetActive(true);
        ImageTire.SetActive(true);
        ImageFillFuel.SetActive(true);
        ImageFuel.SetActive(true);
        RightHud.SetActive(true);
        OptionsHud.SetActive(true);
        RetiredPanel.SetActive(false);
        PitsPanel.SetActive(false);
        tireWearNum = 1;
        fuelAmountNum = 1;
        selected = false;
        tireColorR = 0f;
        tireColorG = 1f;
        fuelColorG = 1f;
    }

    void Update()
    {
        inBox = playerMove.inPitStop;
        if (!inBox)
        {
            TireManager();
            FuelManager();
        }
        if (pitsPanelOpen)
        {
            PitsTimer();
        }
        else
        {
           
        }
    }

    public void PitStopButton()
    {
        if (selected == false)
        {
            BoxInButton.SetActive(true);
            BoxOutButton.SetActive(false);
            selected = true;
            playerMove.PitStopIn();
            PitsPanelManager();
        }
        else
        {
            BoxInButton.SetActive(false);
            BoxOutButton.SetActive(true);
            selected = false;
            playerMove.PitStopOut();
        }
        
    }

    public void CheckStop()
    {
        BoxInButton.SetActive(false);
        BoxOutButton.SetActive(true);
        selected = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TireManager()
    {
        if (tireWearNum > 0)
        {
            ImageTire.GetComponent<Image>().color = tireWearColor;
            tireWearNum -= Time.deltaTime * 0.005f;
            tireWearSlider.value = tireWearNum;
            tireWearColor = new Color(tireColorR, tireColorG, colorB, colorA);
            tireColorR = 1 - tireWearNum;
            tireColorG = tireWearNum;
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
            fuelAmountSlider.value = fuelAmountNum;
            fuelAmountColor = new Color(1f, fuelColorG, colorB, colorA);
            ImageFillFuel.GetComponent<Image>().color = fuelAmountColor;
            ImageFuel.GetComponent<Image>().color = fuelAmountColor;
            fuelColorG = fuelAmountNum;
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
        RetiredPanel.SetActive(true);
        OptionsHud.SetActive(false);
        RightHud.SetActive(false);
        playerPosition = 10;
        Time.timeScale = 0;
    }

    public void RetiredButton()
    {
        SceneManager.LoadScene("PlayerHub");
    }

    public void PitsPanelManager()
    {
        if (!pitsPanelOpen)
        {
            Time.timeScale = 0;
            PitsPanel.SetActive(true);
            pitsPanelOpen = true;
            fuelFillerSlider.value = fuelAmountNum;
            
        }
        else
        {
            Time.timeScale = 1;
            PitsPanel.SetActive(false);
            pitsPanelOpen = false;
        }   
    }

    public void TireChangerManager(int a)
    {
        if ( a == 1 || a == 2 || a == 3)
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
        fuelAmountFill = fuelFillerSlider.value - fuelAmountNum;
        if (fuelAmountFill < 0)
        {
            fuelAmountFill = fuelAmountFill * -1;
        }
        pitsTime = frontTireSelected + rearTireSelected + 6 * fuelAmountFill;
        
        pitsTimeWriter.text = pitsTime.ToString("f2") + "s";
        return pitsTime;
    }

    public void ChangeFuelAmount()
    {
        fuelAmountNum = fuelFillerSlider.value;
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteKey("FrontTireSelected");
        fuelFillerSlider.value = fuelAmountNum;
        rearTireSelected = 0;
        frontTireSelected = 0;
        pitsTime = frontTireSelected + rearTireSelected + 2 * fuelAmountFill;
        pitsTimeWriter.text = pitsTime.ToString("f2") + "s";
    }
}

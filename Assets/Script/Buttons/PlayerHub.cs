using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using Unity.VisualScripting;

public class PlayerHub : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject PlayerHubDownButtons;
    public GameObject PlayerHubTopButtons;
    public GameObject PanelPlayerHub;
    public string playerNameText;
    public string playerBusinessText;
    public string playerMoneyText;
    public Text playerNameWriter;
    public Text playerBusinessWriter;
    public Text playerMoneyWriter;
    public int playerMoneyAmount = 20000;

    void Start()
    {
        OptionsPanel.SetActive(false);
        PlayerHubDownButtons.SetActive(true);
        PlayerHubTopButtons.SetActive(true);
        PanelPlayerHub.SetActive(true);
        playerNameText = PlayerPrefs.GetString("playerName");
        playerBusinessText = PlayerPrefs.GetString("businessName");
        playerNameWriter.text = playerNameText;
        playerBusinessWriter.text = playerBusinessText;
        //string.Format
        playerMoneyText = string.Format("{0:0,0}", playerMoneyAmount);
        //playerMoneyText = playerMoneyAmount.ToString("N2", numberformatinfo.NumberGroupSeparator = ".");
        playerMoneyWriter.text = playerMoneyText;
        
        
    }

    public void Options()
    {
        OptionsPanel.SetActive(true);
        PlayerHubDownButtons.SetActive(false);
        PlayerHubTopButtons.SetActive(false);
    }

    public void Return()
    {
        OptionsPanel.SetActive(false);
        PlayerHubDownButtons.SetActive(true);
        PlayerHubTopButtons.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Track01(Filadelfia)");
    }

    public void Motorcycle()
    {

    }

    public void Pilots()
    {

    }

    public void Mechanics()
    {

    }

    public void HeadQuarters()
    {

    }

    public void Sponsors()
    {

    }

    public void LeaderBoard()
    {

    }
}

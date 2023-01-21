using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mailPanel;
    public GameObject mainMenuPanel;
    //public GameObject optionsPanel;
    public GameObject mainMenuCanvas;
    //public GameObject optionsMenuCanvas;
    public GameObject playerSelectorMenuCanvas;
    public GameObject playerSelectorPanel;
    public GameObject nameError;
    public GameObject businessError;
    public GameObject colorError;
    private string colorName;
    private string playerName;
    private string businessName;
    private bool colorSelected = false;

    

    void Start ()
    {
        
        
        mainMenuPanel.SetActive(true);
        mainMenuCanvas.SetActive(true);
        //optionsPanel.SetActive(false);
        //optionsMenuCanvas.SetActive(false);
        playerSelectorPanel.SetActive(false);
        playerSelectorMenuCanvas.SetActive(false);
        nameError.SetActive(false);
        businessError.SetActive(false);
    }
    
    
    public void Play ()
    {
        
        if (PlayerPrefs.GetInt("gameStarted") == 1)
        {
            SceneManager.LoadScene("PlayerHub");
        }

        else
        {
            //optionsPanel.SetActive(false);
            mainMenuCanvas.SetActive(false);
            //optionsMenuCanvas.SetActive(false);
            playerSelectorPanel.SetActive(true);
            playerSelectorMenuCanvas.SetActive(true);
        }
    }

    /*public void Options()
    {
        //optionsPanel.SetActive(true);
        mainMenuCanvas.SetActive(false);
        //optionsMenuCanvas.SetActive(true);
        playerSelectorPanel.SetActive(false);
        playerSelectorMenuCanvas.SetActive(false);

    }*/

    public void Exit()
    {
        Application.Quit();
    }

    public void Return()
    {
        //optionsPanel.SetActive(false);
        mainMenuCanvas.SetActive(true);
        //optionsMenuCanvas.SetActive(false);
        playerSelectorPanel.SetActive(false);
        playerSelectorMenuCanvas.SetActive(false);
    }

    public void readInputName(string s)
    {
        playerName = s;
    }

    public void readInputBusiness(string s)
    {
        businessName = s;
    }

    public void Continue()
    {
        //color
        colorName = PlayerPrefs.GetString("ColorSelected");
        if (colorName.Length == 4)
        {
            colorSelected = true;
            Debug.Log(colorSelected);
            colorError.SetActive(false);
        } 
        else
        {
            colorSelected = false;
            colorError.SetActive(false);
        }

        if (playerName.Length >= 4)
        {
            nameError.SetActive(false);

            if (businessName.Length >= 4)
            {
                businessError.SetActive(false);
                if (colorSelected == true)
                {
                    PlayerPrefs.SetString("playerName", playerName);
                    PlayerPrefs.SetString("businessName", businessName);
                    InitialSetUp();
                }

                else
                {
                    colorError.SetActive(true);
                }
                
            }
            else
            {
                businessError.SetActive(true);
                Debug.Log("error");
            }
        }

        else
        {
            nameError.SetActive(true);
            Debug.Log("error");
            if (businessName.Length >= 4)
            {
                businessError.SetActive(false);
            }
            else
            {
                businessError.SetActive(true);
                Debug.Log("error");
            }
        }
    }

    public void Mail()
    {
        mailPanel.SetActive(true);
    }

    public void MailReturn()
    {
        mailPanel.SetActive(false);
    }

    public void InitialSetUp()
    {
        PlayerPrefs.SetInt("gameStarted", 1);
        PlayerPrefs.DeleteKey("ColorSelected");
        SceneManager.LoadScene("PlayerHub");
        PlayerPrefs.SetInt("money", 100000);
    }
   
}

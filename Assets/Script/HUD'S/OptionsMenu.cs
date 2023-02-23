
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject optionsMenuCanvas;
    public GameObject mainMenuPanel;
    public GameObject mainMenuCanvas;
    public GameObject optionsButton;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        mainMenuCanvas.SetActive(true);
        optionsPanel.SetActive(false);
        optionsMenuCanvas.SetActive(false);
        optionsButton.SetActive(true);
    }

    public void Options()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        optionsMenuCanvas.SetActive(true);
        mainMenuPanel.SetActive(false);
        mainMenuCanvas.SetActive(false);
        optionsButton.SetActive(false);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        optionsMenuCanvas.SetActive(false);
        mainMenuPanel.SetActive(true);
        mainMenuCanvas.SetActive(true);
        optionsButton.SetActive(true);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}

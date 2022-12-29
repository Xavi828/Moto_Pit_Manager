using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorPlayer : MonoBehaviour
{
    public GameObject player;
    public string colorSelected = "false";
    public Sprite[] selectedSprites;
    public Sprite[] darkSprites;
    public Image[] spriteRendererButton;
    public SpriteRenderer spriteRendererPlayer;
    public int lastColor;

    public void color(int e)
    {
        //Create PlayerPrefs
        PlayerPrefs.SetInt("PlayerColorSelected", e);
        PlayerPrefs.SetString("ColorSelected", "true");

        //Render the buttons
        spriteRendererButton[lastColor].sprite = darkSprites[lastColor];
        spriteRendererButton[e].sprite = selectedSprites[e];

        //ChangeColor
        lastColor = e;
        ChangeColor();
    }

    void ChangeColor()
    {
        spriteRendererPlayer.sprite = selectedSprites[lastColor]; ;
    }




}

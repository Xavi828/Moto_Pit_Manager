using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersColors : MonoBehaviour
{
    public SpriteRenderer[] spritePlayerRenderer;
    public SpriteRenderer playerSpritePlayerRenderer;
    public Sprite[] playerSprites;

    private int playerNum;

    void Start()
    {
        playerNum = PlayerPrefs.GetInt("PlayerNum");

        for (int i = 0; i < spritePlayerRenderer.Length; i++)
        {
            if (i == playerNum)
            {
                playerSpritePlayerRenderer.sprite = playerSprites[i];
            }
            else
            {
                spritePlayerRenderer[i].sprite = playerSprites[i];
            }
            
        }
    }

}

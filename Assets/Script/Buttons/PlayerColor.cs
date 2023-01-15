using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public bool enableColorMenu;
    public enum Player {Red, Orange, Yellow, Green, DarkGreen, DarkBlue, Grey, Blue, Purple, Pink};
    public Player playerSelect;
    public SpriteRenderer spriteRenderer;
    public Sprite[] playerSprites;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("PlayerColorSelected"));

        if (!enableColorMenu)
        {
            ChangePlayerColor();
        }

        
        
        else
        {
            switch (playerSelect)
            {
                case Player.Red:
                    spriteRenderer.sprite = playerSprites[0];
                    break;

                case Player.Yellow:
                    spriteRenderer.sprite = playerSprites[2];
                    break;

                case Player.Orange:
                    spriteRenderer.sprite = playerSprites[1];
                    break;

                case Player.Green:
                    spriteRenderer.sprite = playerSprites[3];
                    break;

                case Player.DarkGreen:
                    spriteRenderer.sprite = playerSprites[4];
                    break;

                case Player.DarkBlue:
                    spriteRenderer.sprite = playerSprites[5];
                    break;

                case Player.Grey:
                    spriteRenderer.sprite = playerSprites[6];
                    break;

                case Player.Blue:
                    spriteRenderer.sprite = playerSprites[7];
                    break;

                case Player.Purple:
                    spriteRenderer.sprite = playerSprites[8];
                    break;

                case Player.Pink:
                    spriteRenderer.sprite = playerSprites[9];
                    break;

                default:
                    break;
            }
        }
    }

    public void ChangePlayerColor()
    {
        switch (PlayerPrefs.GetInt("PlayerColorSelected"))
        {
            case 0:
                spriteRenderer.sprite = playerSprites[0];
                break;

            case 1:
                spriteRenderer.sprite = playerSprites[2];
                break;

            case 2:
                spriteRenderer.sprite = playerSprites[1];
                break;

            case 3:
                spriteRenderer.sprite = playerSprites[3];
                break;

            case 4:
                spriteRenderer.sprite = playerSprites[4];
                break;

            case 5:
                spriteRenderer.sprite = playerSprites[5];
                break;

            case 6:
                spriteRenderer.sprite = playerSprites[6];
                break;

            case 7:
                spriteRenderer.sprite = playerSprites[7];
                break;

            case 8:
                spriteRenderer.sprite = playerSprites[8];
                break;

            case 9:
                spriteRenderer.sprite = playerSprites[9];
                break;

            default:
                break;
        }
    }
}

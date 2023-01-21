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
    public bool playerSetUp;
    public string color = "no";

    void Start()
    {
        if(!enableColorMenu)
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
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Red":
                spriteRenderer.sprite = playerSprites[0];
                break;

            case "Yellow":
                spriteRenderer.sprite = playerSprites[2];
                break;

            case "Orange":
                spriteRenderer.sprite = playerSprites[1];
                break;

            case "Green":
                spriteRenderer.sprite = playerSprites[3];
                break;

            case "DarkGreen":
                spriteRenderer.sprite = playerSprites[4];
                break;

            case "DarkBlue":
                spriteRenderer.sprite = playerSprites[5];
                break;

            case "Grey":
                spriteRenderer.sprite = playerSprites[6];
                break;

            case "Blue":
                spriteRenderer.sprite = playerSprites[7];
                break;

            case "Purple":
                spriteRenderer.sprite = playerSprites[8];
                break;

            case "Pink":
                spriteRenderer.sprite = playerSprites[9];
                break;

            default:
                break;
        }
    }
}

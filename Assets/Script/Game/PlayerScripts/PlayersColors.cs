using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersColors : MonoBehaviour
{
    public SpriteRenderer[] spritePlayerRenderer;
    public Sprite[] playerSprites;

    private int playerNum;
    private GameObject gameObject;

    void Start()
    {
        for (int i = 0; i < spritePlayerRenderer.Length; i++)
        {
            spritePlayerRenderer[i].sprite = playerSprites[i];
        }
    }

}

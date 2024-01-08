using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackGround : MonoBehaviour
{
    Image background;

    void Start()
    {
        background = this.GetComponent<Image>();
    }

    public void moveBackGround(Vector2 playerPos)
    {
        background.material.mainTextureOffset = new Vector2(playerPos.x / 100, playerPos.y / 100);
    }
}

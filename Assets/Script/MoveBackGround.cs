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

    public void moveBackGround(float playerPos)
    {
        background.material.mainTextureOffset = new Vector2(playerPos / 100, 0f);
    }
}

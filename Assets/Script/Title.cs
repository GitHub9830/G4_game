using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//�}�E�X���N���b�N
        {
            SceneManager.LoadScene("GameScene");//some_sensei�V�[�������[�h����
        }

    }
}
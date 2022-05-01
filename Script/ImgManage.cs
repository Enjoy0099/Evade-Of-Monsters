using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgManage : MonoBehaviour
{
    public GameObject playerIsAlive;
    public GameObject lastImgEnable;
    public GameObject Spawner;

    private void Update()
    {
        if (playerIsAlive)
        {
            lastImgEnable.SetActive(false);
        }
        else
        {
            lastImgEnable.SetActive(true);
            Spawner.SetActive(false);
        }
    }

}

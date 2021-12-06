using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GameObject canvaas;
    public GameObject shopManager;

    public void OpenCanvas()
    {
        if (canvaas != null)
        {
            canvaas.SetActive(true);
            shopManager.SetActive(true);
        }
    }
}

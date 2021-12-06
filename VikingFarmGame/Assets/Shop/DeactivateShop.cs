using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateShop : MonoBehaviour
{
    public GameObject canvaas;

    public void OpenCanvas()
    {
        if(canvaas != null)
        {
            canvaas.SetActive(false);

        }
    }
}

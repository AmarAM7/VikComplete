using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime;
    public UnityEvent onLongClick;

    

    private Aim isAim;

    // Start is called before the first frame update
    void Start()
    {
        //playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer > requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();;
                Reset();
            }
            isAim = GetComponent<Aim>();
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        
    }

}

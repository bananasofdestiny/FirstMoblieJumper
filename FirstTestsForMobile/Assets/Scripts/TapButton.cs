using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TapButton : Button
{
    
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        GameManager.Instance.StartGame();
        gameObject.SetActive(false);
    }
}

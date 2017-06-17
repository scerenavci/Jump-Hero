using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class JumpButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    public void OnPointerDown(PointerEventData data)
    {
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.SetPower(true);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.SetPower(false);
        }
    }


}

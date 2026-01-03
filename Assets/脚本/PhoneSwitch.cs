

using System;
using Unity.VisualScripting;
using UnityEngine;

public class PhoneSwitch: MonoBehaviour
{
    public GameObject PhoneHUD;
    
    private void Awake()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            PhoneHUD.SetActive(true);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            PhoneHUD.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [Header("Scripts")]
    public ResourceManagementScript resourceManagementScript;

    [Header("Panels")]
    public GameObject ResourcesApp;
    public GameObject TextingApp;
    public GameObject PowerApp;
    public GameObject PhoneOff001;
    public GameObject PhoneOff002;

    [Header("Other")]
    public bool isPowerOFF;
    public int pwrOffFrameCounter;

    // Start is called before the first frame update
    void Start()
    {
        ResourcesApp.SetActive(false);
        TextingApp.SetActive(false);
        PowerApp.SetActive(false);

        PhoneOff001.SetActive(false);
        PhoneOff002.SetActive(false);

        isPowerOFF = false;
        pwrOffFrameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResourcesApp.SetActive(true);
            TextingApp.SetActive(false);
            PowerApp.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ResourcesApp.SetActive(false);
            TextingApp.SetActive(true);
            PowerApp.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            ResourcesApp.SetActive(false);
            TextingApp.SetActive(false);
            PowerApp.SetActive(true);
        }

        if (resourceManagementScript.powerLeft <= 0)
        {
            isPowerOFF = true;
        }

        
        if(isPowerOFF)
        {
            pwrOffFrameCounter++;
            PhoneOff001.SetActive(true);
        }
        else
        {
            pwrOffFrameCounter = 0;
            PhoneOff001.SetActive(false);
            PhoneOff002.SetActive(false);
        }

        if(pwrOffFrameCounter >= 60*5)
        {
            PhoneOff002.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [Header("Scripts")]
    public ResourceManagementScript resourceManagementScript;
    public TextingScript textingScript;
   // public Enemy01AIScript enemy01AIScript;

    [Header("Panels")]
    public GameObject ResourcesApp;
    public GameObject TextingApp;
    public GameObject PowerApp;
    public GameObject PhoneOff001;
    public GameObject PhoneOff002;

    [Header("Blood")]
    public GameObject BloodEffect1;
    public GameObject BloodEffect2;
    public GameObject BloodPnl;

    [Header("Other")]
    public bool isPowerOFF;
    public int pwrOffFrameCounter;
    public int HealthState;
    public int HealthStateFrameCounter;
    public GameObject pnlDeath;

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

        HealthState = 0; //okay
        HealthStateFrameCounter = 0;
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

            textingScript.notification.SetActive(false);
        }

        if (TextingApp.active)
        {
            textingScript.notification.SetActive(false);
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




        //health STATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        if(HealthState == 1)
        {
            //Blood effect 1
            BloodEffect1.SetActive(true);
            BloodEffect2.SetActive(false);

        }
        else if (HealthState == 2)
        {
            //Blood effect 2
            BloodEffect1.SetActive(false);
            BloodEffect2.SetActive(true);

        }
        else if (HealthState == 3)
        {
            //Death
            pnlDeath.SetActive(true);
        }
        else if(HealthState == 0)
        {
            //okay
            BloodEffect1.SetActive(false);
            BloodEffect2.SetActive(false);
            BloodPnl.SetActive(false);
        }


        if(HealthState != 0)
        {
            HealthStateFrameCounter++;
            BloodPnl.SetActive(true);
        }

        if(HealthStateFrameCounter >= 60*5) //seconds
        {
            HealthState--;
            HealthStateFrameCounter = 0;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //death
        if (pnlDeath.active)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MainMenu");
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("KaiScene");
            }
        }
    }
}

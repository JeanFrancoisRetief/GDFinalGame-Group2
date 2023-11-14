using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrigger : MonoBehaviour
{
    [Header("Scripts")]
    public ResourceManagementScript resourceManagementScript;
    public UIScript uIScript;
    public SoundScript soundScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChargeTrigger")
        {
            resourceManagementScript.powerLeft += 20;
            soundScript.chargePhone.Play();
            if(resourceManagementScript.powerLeft > 100)
            {
                resourceManagementScript.powerLeft = 100;
            }
            if(uIScript.isPowerOFF == true)
            {
                //uIScript.PhoneOff001.SetActive(false);
                //uIScript.PhoneOff002.SetActive(false);
                resourceManagementScript.powerLeft += 10;
                uIScript.isPowerOFF = false;
            }
            other.enabled = false;
        }
    }

    
}

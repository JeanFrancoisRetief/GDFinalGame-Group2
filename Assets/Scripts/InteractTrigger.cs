using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour
{
    public ResourceManagementScript resourceManagementScript;
    public GameObject Interact_E_Icon;

    public KeyScript keyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        Interact_E_Icon.SetActive(false);
        resourceManagementScript.CanInteract = false;
        resourceManagementScript.TRIGGERED = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(resourceManagementScript.CanInteract == true)
        {
            Interact_E_Icon.SetActive(true);
        }
        else
        {
            Interact_E_Icon.SetActive(false);
        }


        if((resourceManagementScript.noiseLevel < 3) && resourceManagementScript.TRIGGERED)//after noise increase
        {
            resourceManagementScript.isNoiseDistracted = true;
            resourceManagementScript.TRIGGERED = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            
            resourceManagementScript.CanInteract = true;

            keyScript.hintText.text = "Press 'E' to charge generator";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            
            resourceManagementScript.CanInteract = false;

            keyScript.hintText.text = "";
        }
    }
}

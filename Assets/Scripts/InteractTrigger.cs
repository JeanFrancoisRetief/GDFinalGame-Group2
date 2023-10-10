using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour
{
    public ResourceManagementScript resourceManagementScript;
    public GameObject Interact_E_Icon;
    // Start is called before the first frame update
    void Start()
    {
        Interact_E_Icon.SetActive(false);
        resourceManagementScript.CanInteract = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            Interact_E_Icon.SetActive(true);
            resourceManagementScript.CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            Interact_E_Icon.SetActive(false);
            resourceManagementScript.CanInteract = false;
        }
    }
}

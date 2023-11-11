using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [Header("Scripts")]
    public ResourceManagementScript resourceManagementScript;
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
        if(other.tag == "LightTrigger")
        {
            resourceManagementScript.inLight1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag == "LightTrigger")
        {
            resourceManagementScript.inLight1 = false;
        }
    }
}

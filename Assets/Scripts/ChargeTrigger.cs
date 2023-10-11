using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrigger : MonoBehaviour
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
        if (other.tag == "ChargeTrigger")
        {
            resourceManagementScript.powerLeft += 20;
            if(resourceManagementScript.powerLeft > 100)
            {
                resourceManagementScript.powerLeft = 100;
            }
            other.enabled = false;
        }
    }

    
}

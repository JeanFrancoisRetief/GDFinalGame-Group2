using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTrigger : MonoBehaviour
{
    public GameObject ObjectInteractPanel;
    public GameObject UIObject1;
    public GameObject UIObject2;
    public GameObject UIObject3;
    public GameObject UIObject4;
    public GameObject UIObject5;
    public GameObject UIObject1Broken;
    public Text InteractTextHint;
    public bool isBroken;

    public KeyScript keyScript;
    public SoundScript soundScript;


    public bool isViewingKeyObject;

    // Start is called before the first frame update
    void Start()
    {
        InteractTextHint.text = "";
        
        UIObject1.SetActive(false);
        UIObject2.SetActive(false);
        UIObject3.SetActive(false);
        UIObject4.SetActive(false);
        UIObject5.SetActive(false);
        UIObject1Broken.SetActive(false);
        ObjectInteractPanel.SetActive(false);

        isViewingKeyObject = false;

        isBroken = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjectTrigger1" || other.tag == "ObjectTrigger2" || other.tag == "ObjectTrigger3" || other.tag == "ObjectTrigger4" || other.tag == "ObjectTrigger5")
        {
            InteractTextHint.text = "Press Q to interact.";
        }
           
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ObjectTrigger1") ///key
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                InteractTextHint.text = "Press B to break the bottle";
                ObjectInteractPanel.SetActive(true);
                UIObject1.SetActive(true);

                isViewingKeyObject = true;
            }

            if(isViewingKeyObject && Input.GetKeyDown(KeyCode.B)) //break
            {
                InteractTextHint.text = "";
                soundScript.keys.Play();
                keyScript.hasKeyThree = true;
                keyScript.KeyThree.SetActive(false);

                //break effect
                UIObject1Broken.SetActive(true);
                UIObject1.SetActive(false);
                isBroken = true;
            }

        }
        if (other.tag == "ObjectTrigger2") ///code
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                InteractTextHint.text = "";
                ObjectInteractPanel.SetActive(true);
                UIObject2.SetActive(true);
            }
            //CODE IS VISABLE ON UIOBJECT2
        }
        if (other.tag == "ObjectTrigger3")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                InteractTextHint.text = "";
                ObjectInteractPanel.SetActive(true);
                UIObject3.SetActive(true);
            }
        }
        if (other.tag == "ObjectTrigger4")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                InteractTextHint.text = "";
                ObjectInteractPanel.SetActive(true);
                UIObject4.SetActive(true);
            }
        }
        if (other.tag == "ObjectTrigger5")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                InteractTextHint.text = "";
                ObjectInteractPanel.SetActive(true);
                UIObject5.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ObjectTrigger1" || other.tag == "ObjectTrigger2" || other.tag == "ObjectTrigger3" || other.tag == "ObjectTrigger4" || other.tag == "ObjectTrigger5")
        {
            InteractTextHint.text = "";
            
            UIObject1.SetActive(false);
            UIObject2.SetActive(false);
            UIObject3.SetActive(false);
            UIObject4.SetActive(false);
            UIObject5.SetActive(false);
            UIObject1Broken.SetActive(false);
            ObjectInteractPanel.SetActive(false);

            isViewingKeyObject = false;
        }

        if (other.tag == "ObjectTrigger1" && isBroken)
        {
            other.enabled = false;
        }
    }
}

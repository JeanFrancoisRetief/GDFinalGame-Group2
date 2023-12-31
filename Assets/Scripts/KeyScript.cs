using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyScript : MonoBehaviour
{
    public GameObject KeyOne;
    public GameObject KeyTwo;
    public GameObject KeyThree;
    public GameObject KeyFour;

    public GameObject DoorOne;
    public GameObject DoorTwo;
    public GameObject DoorThree;
    public GameObject DoorFour;

    public GameObject Keypad;
    public bool inKeyPad;

    public Text warningText;
    public Text hintText;
    public int textFrameCounter;
    public ResourceManagementScript resourceScript;
    public SoundScript soundScript;

    public bool hasKeyOne = false;
    public bool hasKeyTwo = false;
    public bool hasKeyThree = false;
    public bool hasKeyFour = false;
    // Start is called before the first frame update
    void Start()
    {
        textFrameCounter = 0;

        inKeyPad = false;

        Keypad.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (warningText.text != "")
        {
            textFrameCounter++;
        }

        if (textFrameCounter >= 60 * 3)
        {
            warningText.text = "";
            textFrameCounter = 0;
        }

        if(resourceScript.TRIGGERED == true)
        {
            hasKeyFour = true;
            StartCoroutine(generators());
            KeyFour.SetActive(false);
        }
    }

    public IEnumerator generators()
    {
        soundScript.generator.Play();
     
        soundScript.generator2.Play();

        yield return new WaitForSeconds(10f);

        soundScript.generator.volume = soundScript.generator.volume / 2;

        soundScript.generator2.volume = soundScript.generator2.volume / 2;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("KeyOne"))
        {
            //hintText.text = "Press Q to pick up key";

            if (Input.GetKeyDown(KeyCode.Q))
            {
                hintText.text = "";
                soundScript.keys.Play();
                hasKeyOne = true;
                KeyOne.SetActive(false);
            }
        }

        if (other.CompareTag("KeyTwo"))
        {
            //hintText.text = "Press Q to pick up key";
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hintText.text = "";
                soundScript.keys.Play();
                hasKeyTwo = true;
                KeyTwo.SetActive(false);
            }
        }

        /*if (other.CompareTag("KeyThree"))
        {
            hintText.text = "Press Q to pick up key";
            if (Input.GetKeyDown("Q"))
            {
                hintText.text = "";
                hasKeyThree = true;
                KeyThree.SetActive(false);
            }
        }*/

        if (other.CompareTag("KeyFour"))
        {
            //hintText.text = "Press Q to pick up key";
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hintText.text = "";
                soundScript.keys.Play();
                hasKeyFour = true;
                KeyFour.SetActive(false);
            }
        }

        if (other.CompareTag("DoorOne"))
        {

            if (hasKeyOne)
            {
                //hintText.text = "Press Q to open door";
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hintText.text = "";
                    soundScript.doorOpen.Play();
                    DoorOne.SetActive(false);
                }
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }

        if (other.CompareTag("DoorTwo"))
        {

            if (hasKeyTwo)
            {
                //hintText.text = "Press Q to open door";
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hintText.text = "";
                    soundScript.doorOpen.Play();
                    DoorTwo.SetActive(false);
                }
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }

        if (other.CompareTag("DoorThree"))
        {

            if (hasKeyThree)
            {
                //hintText.text = "Press Q to open door";
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hintText.text = "";
                    soundScript.doorOpen.Play();
                    DoorThree.SetActive(false);
                }
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }

        if (other.CompareTag("DoorFour"))
        {

            if (hasKeyFour)
            {
                //hintText.text = "Press Q to open door";
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    hintText.text = "";
                    soundScript.doorOpen.Play();
                    DoorFour.SetActive(false);
                }
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }


        if (other.CompareTag("Elevator"))
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!inKeyPad)
                {
                    hintText.text = "Press Q to exit keypad";
                    Keypad.SetActive(true);
                    inKeyPad = true;
                }
                else
                {
                    hintText.text = "Press Q to use keypad";
                    Keypad.SetActive(false);
                    inKeyPad = false;
                }

            }

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            hintText.text = "Press Q to use keypad";
        }

        if (other.CompareTag("KeyOne"))
        {
            hintText.text = "Press Q to pick up key";

        }

        if (other.CompareTag("KeyTwo"))
        {
            hintText.text = "Press Q to pick up key";
           
        }

        /*if (other.CompareTag("KeyThree"))
        {
            hintText.text = "Press Q to pick up key";
            if (Input.GetKeyDown("Q"))
            {
                hintText.text = "";
                hasKeyThree = true;
                KeyThree.SetActive(false);
            }
        }*/

        if (other.CompareTag("KeyFour"))
        {
            hintText.text = "Press Q to pick up key";
           
        }

        if (other.CompareTag("DoorOne"))
        {

            if (hasKeyOne)
            {
                hintText.text = "Press Q to open door";
                
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }

        if (other.CompareTag("DoorTwo"))
        {

            if (hasKeyTwo)
            {
                hintText.text = "Press Q to open door";
                
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }

        if (other.CompareTag("DoorThree"))
        {

            if (hasKeyThree)
            {
                hintText.text = "Press Q to open door";
               
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }

        if (other.CompareTag("DoorFour"))
        {

            if (hasKeyFour)
            {
                hintText.text = "Press Q to open door";
               
            }
            else
            {
                warningText.text = "Get The Key Stupid!";
            }
        }


        if (other.CompareTag("Elevator"))
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!inKeyPad)
                {
                    hintText.text = "Press Q to exit keypad";
                    //Keypad.SetActive(true);
                    //inKeyPad = true;
                }
                else
                {
                    hintText.text = "Press Q to use keypad";
                    //Keypad.SetActive(false);
                   // inKeyPad = false;
                }

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            hintText.text = "";

            Keypad.SetActive(false);
            inKeyPad = false;
        }
        warningText.text = "";
        hintText.text = "";
    }
}

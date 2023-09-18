using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagementScript : MonoBehaviour
{
    [Header("Player")]
    public GameObject PlayerPrefab;
    public Vector3 StopPosition;

    [Header("Frame counters")]
    public int staminaFrameCounter;

    [Header("UI")]
    public Slider StaminaSlider;
    public Text NoiseMeterText; //can be replaced by images
    public Text SightMeterText; //can be replaced by images
    public Text PowerLeftText;

    [Header("Stamina")]
    public bool isWalking;
    public bool isSprinting;

    [Space(10)]
    public float staminaValue;
    public float staminaIncreaseValue = 0.1f;
    public float staminaDecreaseValue;

    [Space(10)]
    public float walkDecreaseValue = 0.2f;
    public float sprintDecreaseValue = 0.5f;

    [Header("Noise")]
    public int noiseLevel = 0;
    public int noiseChecker1;
    public int noiseChecker2;
    public int noiseChecker3;
    public int noiseChecker4;
    public int noiseChecker5;

    [Header("Sight")]
    public int sightLevel = 0;
    public int sightChecker1;
    public int sightChecker2;
    public int sightChecker3;

    [Header("Power")]
    public bool isFlashlightOn;

    [Space(10)]
    public float powerLeft = 100;
    public float powerDrainValue;
    public float powerCheckerConstant = 0.1f;
    public float powerCheckerFlashlight = 0;
    public float powerCheckerOther = 0;



    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        isSprinting = false;
        isFlashlightOn = false;
        staminaValue = 100;

        staminaFrameCounter = 0;


        noiseLevel = 0;
        sightLevel = 0;
        powerLeft = 100;
        powerCheckerFlashlight = 0;
        powerCheckerOther = 0;


    noiseChecker1 = 0;
        noiseChecker2 = 0;
        noiseChecker3 = 0;
        noiseChecker4 = 0;
        noiseChecker5 = 0;

        StopPosition = new Vector3(0, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        Stamina();
        Power();
        Noise();
        Sight();
        
    }

    public void FlashLightOn()
    {
        //
    }
    public void FlashLightOff()
    {
        //
    }

    public void Power()
    {
        //display
        PowerLeftText.text = (Mathf.Floor(powerLeft)).ToString() + "%";

        //input
        if(Input.GetKeyDown(KeyCode.F) && !isFlashlightOn)
        {
            isFlashlightOn = true;
            FlashLightOn();
        } 
        else if (Input.GetKeyDown(KeyCode.F) && isFlashlightOn)
        {
            isFlashlightOn = false;
            FlashLightOff();
        }

  

        //checkers
        //2
        if (isFlashlightOn)
        {
            powerCheckerFlashlight = 0.05f;
        }
        else
        {
            powerCheckerFlashlight = 0;
        }


        powerDrainValue = powerCheckerConstant + powerCheckerFlashlight + powerCheckerOther;
        powerLeft -= powerDrainValue;

    }

    public void Noise()
    {
        //check state and display
        if(noiseLevel == 0)
        {
            NoiseMeterText.text = "|";
        }
        else if (noiseLevel == 1)
        {
            NoiseMeterText.text = "[]";
        }
        else if (noiseLevel == 2)
        {
            NoiseMeterText.text = "[][]";
        }
        else if (noiseLevel == 3)
        {
            NoiseMeterText.text = "[][][]";
        }
        else if (noiseLevel == 4)
        {
            NoiseMeterText.text = "[][][][]";
        }
        else if (noiseLevel == 4)
        {
            NoiseMeterText.text = "[][][][][]";
        }

        //checkers
        //1
        if(isWalking)
        {
            noiseChecker1 = 1;
        }
        else
        {
            noiseChecker1 = 0;
        }
        //2
        if (isSprinting)
        {
            noiseChecker2 = 1;
        }
        else
        {
            noiseChecker2 = 0;
        }
        //3

        //4

        //5



        noiseLevel = noiseChecker1 + noiseChecker2 + noiseChecker3 + noiseChecker4 + noiseChecker5;

    }

    public void Sight()
    {
        //check state and display
        if (sightLevel == 0)
        {
            SightMeterText.text = "-----";
        }
        else if (sightLevel == 1)
        {
            SightMeterText.text = "--•--";
        }
        else if (sightLevel == 2)
        {
            SightMeterText.text = "(-•-)";
        }
        else if (sightLevel == 3)
        {
            SightMeterText.text = "[Alert](-•-)[Alert]";
        }

        //checkers
        //1 ___________________________________test
        if (isWalking)
        {
            sightChecker1 = 1;
        }
        else
        {
            sightChecker1 = 0;
        }
        //2 ___________________________________test
        if (isSprinting)
        {
            sightChecker2 = 1;
        }
        else
        {
            sightChecker2 = 0;
        }
        //3


        sightLevel = sightChecker1 + sightChecker2 + sightChecker3;

    }

    public void Stamina()
    {
        //Display
        StaminaSlider.value = staminaValue;

        //max
        if (staminaValue > 100)
        {
            staminaValue = 100;
        }

        //check state
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            
        }
        else
        {
            isWalking = false;
        }
        if((isWalking == true) && Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }



        staminaFrameCounter++;

        //increase stamina while not walking or sprinting.
        if(staminaFrameCounter >= 60)
        {
            if(!isWalking && (staminaValue <= 100))
            {
                staminaValue += staminaIncreaseValue;
            }

            StopPosition = PlayerPrefab.transform.position;
            staminaFrameCounter = 0;
        }

        //decrease stamina while walking or sprinting
        if(isSprinting)
        {
            staminaDecreaseValue = sprintDecreaseValue;
        }
        else if(isWalking)
        {
            staminaDecreaseValue = walkDecreaseValue;
        }
        else
        {
            staminaDecreaseValue = 0;
        }

        staminaValue -= staminaDecreaseValue;
        

        if(staminaValue <= 0)
        {
            staminaValue = 0;
            PlayerPrefab.transform.position = StopPosition;
        }

    }

    /*
     totalActiveBars = varA + varB + varC + varD + varE + 1; //Zeros and Ones being summed up

        if(totalActiveBars == 1)
        {
            oneBar.SetActive(true);
        }
        else
        {
            oneBar.SetActive(false);
        }
        if(totalActiveBars == 2)
        {
            twoBars.SetActive(true);
        }
        else
        {
            twoBars.SetActive(false);
        }
        if(totalActiveBars == 3)
        {
            threeBars.SetActive(true);
        }
        else
        {
            threeBars.SetActive(false);
        }
        if(totalActiveBars == 4)
        {
            fourBars.SetActive(true);
        }
        else
        {
            fourBars.SetActive(false);
        }
        if (totalActiveBars == 5)
        {
            fiveBars.SetActive(true);
        }
        else
        {
            fiveBars.SetActive(false);
        }
        decreaseSpeed = decVarA1 + decVarB1 + decVarC1 + decVarD1 + decVarE1 + 0.1f;

        if(CameraScript.isGameActive == true)
        {
            powerLeft -= decreaseSpeed * Time.deltaTime;
            powerLeft = Mathf.Max(powerLeft, 0f);

            UpdatePowerText(); // Call the method to update the UI text
        }
     */
}

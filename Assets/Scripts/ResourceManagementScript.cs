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

    [Header("Scripts")]
    public SoundScript soundScript;

    [Header("UI")]
    public Slider StaminaSlider;
    public Text NoiseMeterText; //can be replaced by images
    public Text SightMeterText; //can be replaced by images
    public Text PowerLeftText;
    public GameObject FlashLightDebug;
    public GameObject EnvDebug;
    public bool EnvDebugActive;
    public GameObject WalkDebug;
    public GameObject RunDebug;

    [Space(10)]
    public GameObject PowerBar1;
    public GameObject PowerBar2;
    public GameObject PowerBar3;
    public GameObject PowerBar4;
    public GameObject PowerBar5;

    [Header("Stamina")]
    public bool isWalking;
    public bool isSprinting;
    public bool hasPlayed;
    private bool isWalkingCheck;
    private bool isRunningCheck;

    [Space(10)]
    public float staminaValue;
    public float staminaIncreaseValue = 0.2f;
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

    [Space(10)]
    public bool TRIGGERED;
    public bool isNoiseDistracted;
    public int distractCounter;

    [Header("Sight")]
    public int sightLevel = 0;
    public int sightChecker1;
    public int sightChecker2;
    public int sightChecker3;

    [Space(10)]
    public bool inLight1;
    public bool inLight2;

    [Header("Power")]
    public GameObject flashlight;
    public bool isFlashlightOn;
    public bool CanInteract;
    public bool isEnvActive;
    public int EnvCounter;

    [Space(10)]
    public float powerLeft = 100;
    public float powerDrainValue;
    public float powerCheckerConstant = 0.1f;
    public float powerCheckerFlashlight = 0;
    public float powerCheckerOther = 0;
    private bool isPhoneDead;



    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        isSprinting = false;
        isFlashlightOn = false;
        staminaValue = 100;
        hasPlayed = false;
        isWalkingCheck = false;
        isRunningCheck = false;

        staminaFrameCounter = 0;
        TRIGGERED = false;

        noiseLevel = 0;
        sightLevel = 0;
        powerLeft = 100;
        powerCheckerFlashlight = 0;
        powerCheckerOther = 0;

        isEnvActive = false;
        EnvCounter = 0;


        noiseChecker1 = 0;
        noiseChecker2 = 0;
        noiseChecker3 = 0;
        noiseChecker4 = 0;
        noiseChecker5 = 0;

        isNoiseDistracted = false;
        distractCounter = 0;

        StopPosition = new Vector3(0, 0, 0);

        PowerBar1.SetActive(false);
        PowerBar2.SetActive(false);
        PowerBar3.SetActive(false);
        PowerBar4.SetActive(false);
        PowerBar5.SetActive(false);

        FlashLightDebug.SetActive(false);
        EnvDebug.SetActive(false);
        EnvDebugActive = false;
        WalkDebug.SetActive(false);
        RunDebug.SetActive(false);

        inLight1 = false;
        inLight2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Stamina();
        Power();
        Noise();
        Sight();

        DebugExtras();

        if(isFlashlightOn)
        {
            flashlight.SetActive(true);
        }
        else
        {
            flashlight.SetActive(false);
        }
    }

    public void DebugExtras()
    {
        if(Input.GetKeyDown(KeyCode.E) && CanInteract)
        {
            EnvDebug.SetActive(!EnvDebugActive);
            EnvDebugActive = !EnvDebugActive;
        }

        /*
        if(EnvDebugActive)
        {
            powerCheckerOther = 0.1f;
        }
        else
        {
            powerCheckerOther = 0;
        }
        */

        if(isWalking)
        {
            WalkDebug.SetActive(true);
        }
        else
        {
            WalkDebug.SetActive(false);
        }

        if (isSprinting)
        {
            RunDebug.SetActive(true);
        }
        else
        {
            RunDebug.SetActive(false);
        }

    }

    public void FlashLightOn()
    {
        FlashLightDebug.SetActive(true);
    }
    public void FlashLightOff()
    {
        FlashLightDebug.SetActive(false);
    }

    public void Power()
    {
        //display
        PowerLeftText.text = (Mathf.Floor(powerLeft)).ToString() + "%";

        if(powerLeft <= 0)
        {
            powerLeft = 0;
            PowerLeftText.text = "0%";

            isPhoneDead = true;
            isFlashlightOn = false;
        }

        if (isPhoneDead)
        {
            StartCoroutine(phoneDead());
        }

        if (powerLeft > 0)
        {
            isPhoneDead = false;

            //input
            if (Input.GetKeyDown(KeyCode.F) && !isFlashlightOn)
            {
                isFlashlightOn = true;
                soundScript.flashlight.Play();
                FlashLightOn();
            }
            else if (Input.GetKeyDown(KeyCode.F) && isFlashlightOn)
            {
                isFlashlightOn = false;
                soundScript.flashlight.Play();
                FlashLightOff();
            }
        }
  

        //checkers
        //2
        if (isFlashlightOn)
        {
            powerCheckerFlashlight = 0.005f;
        }
        else
        {
            powerCheckerFlashlight = 0;
        }

        if (Input.GetKeyDown(KeyCode.E) && CanInteract)
        {
            isEnvActive = true;
            CanInteract = false;
            TRIGGERED = true;
        }

        if(isEnvActive)
        {
            powerCheckerOther = 0.07f;
            if (EnvCounter < 60*5)
            {
                EnvCounter++;
                
            }
            else
            {
                
                isEnvActive = false;
            }
        }
        else
        {
            EnvCounter = 0;
            powerCheckerOther = 0;
        }


        powerDrainValue = powerCheckerConstant + powerCheckerFlashlight + powerCheckerOther;
        powerLeft -= powerDrainValue;

        if(isFlashlightOn && powerCheckerOther != 0)
        {
            PowerBar1.SetActive(false);
            PowerBar2.SetActive(false);
            PowerBar3.SetActive(false);
            PowerBar4.SetActive(false);
            PowerBar5.SetActive(true);
        }
        else if(isFlashlightOn)
        {
            PowerBar1.SetActive(false);
            PowerBar2.SetActive(true);
            PowerBar3.SetActive(false);
            PowerBar4.SetActive(false);
            PowerBar5.SetActive(false);
        }
        else if(powerCheckerOther != 0)
        {
            PowerBar1.SetActive(false);
            PowerBar2.SetActive(false);
            PowerBar3.SetActive(true);
            PowerBar4.SetActive(false);
            PowerBar5.SetActive(false);
        }
        else
        {
            PowerBar1.SetActive(true);
            PowerBar2.SetActive(false);
            PowerBar3.SetActive(false);
            PowerBar4.SetActive(false);
            PowerBar5.SetActive(false);
        }



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
        else if (noiseLevel == 5)
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
        if (isEnvActive)
        {
            noiseChecker3 = 3;
        }
        else
        {
            noiseChecker3 = 0;
        }

        //4

        //5

        if(isNoiseDistracted)
        {
            distractCounter++;
            if(distractCounter >= 60*10)
            {
                isNoiseDistracted = false;
            }
            //--------------------------------------------------------------------------------------------CHANGE NOISE SENSITIVE ENEMIES' TARGET TO NOISE SOURCE------------



            //--------------------------------------------------------------------------------------------CHANGE NOISE SENSITIVE ENEMIES' TARGET TO NOISE SOURCE------------
        }
        else
        {
            distractCounter = 0;
        }


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
        if (isFlashlightOn)
        {
            sightChecker1 = 1;
        }
        else
        {
            sightChecker1 = 0;
        }
        //2 ___________________________________test
        if (inLight1)
        {
            sightChecker2 = 1;
        }
        else
        {
            sightChecker2 = 0;
        }
        //3
        if (inLight2)
        {
            sightChecker3 = 1;
        }
        else
        {
            sightChecker3 = 0;
        }


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
            if(!hasPlayed)
            {
                soundScript.lowStamina.Play();
                hasPlayed = true;
            }
            PlayerPrefab.transform.position = StopPosition;
        }

        if (isWalking)
        {
            if (!isWalkingCheck)
            {
                soundScript.walking.Play();
                isWalkingCheck = true;
            }

        }
        
        if (isSprinting)
        {
            if (!isRunningCheck)
            {
                soundScript.running.Play();
                isRunningCheck = true;
            }
        }    

        if (hasPlayed)
        {
            StartCoroutine(staminaSound());
        }

        if (isWalkingCheck)
        {
            StartCoroutine(walkingSound());
        }

        if (!isWalking)
        {
            soundScript.walking.Stop();
            isWalkingCheck = false;
        }

        if (isRunningCheck)
        {
            StartCoroutine(runningSound());
        }

        if (!isSprinting)
        {
            soundScript.running.Stop();
            isRunningCheck = false;
        }
    }

    public IEnumerator staminaSound()
    {
        yield return new WaitForSeconds(12f);

        hasPlayed = false;
    }

    public IEnumerator walkingSound()
    {
        yield return new WaitForSeconds(18f);

        isWalkingCheck = false;
    }

    public IEnumerator runningSound()
    {
        yield return new WaitForSeconds(3f);

        isRunningCheck = false;
    }

    public IEnumerator phoneDead()
    {
        soundScript.phoneDead.Play();

        yield return new WaitForSeconds(3f);

        soundScript.phoneDead.volume = 0;

        if (powerLeft > 0)
        {
            soundScript.phoneDead.volume = 0.05f;
            isPhoneDead = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagementScript : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Power();
        Noise();
        Sight();
        Stamina();
    }

    public void Power()
    {
        //if()
        //{
            //PowerVar1 = 1;
        //}

    }

    public void Noise()
    {

    }

    public void Sight()
    {

    }

    public void Stamina()
    {

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

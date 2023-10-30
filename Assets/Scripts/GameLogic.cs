using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public float playerPositionY;
    public Floor currentFloor;
    public bool RunOncePlease;
    public enum Floor
    { 
        GROUND,
        FIRST,
        SECOND,
        THIRD
    }

    /*[Header("Triggers")]
    public GameObject ThirdToSecond;
    public GameObject SecondToThird;

    public GameObject SecondToFirst;
    public GameObject FirstToSecond;

    public GameObject FirstToGround;
    public GameObject GroundToFirst;*/

    [Header("Third floor enemies")]
    public GameObject TFenemy001;

    [Space(10)]
    public Vector3 TFenemy001pos;


    [Header("Second floor enemies")]
    public GameObject SFenemy001;
    public GameObject SFenemy002;

    [Space(10)]
    public Vector3 SFenemy001pos;
    public Vector3 SFenemy002pos;

    [Header("First floor enemies")]
    public GameObject FFenemy001;
    public GameObject FFenemy002;
    public GameObject FFenemy003;

    [Space(10)]

    public Vector3 FFenemy001pos;
    public Vector3 FFenemy002pos;
    public Vector3 FFenemy003pos;

    [Header("Ground floor enemies")]
    public GameObject GFenemy001;
    public GameObject GFenemy002;
    public GameObject GFenemy003;
    public GameObject GFenemy004;

    [Space(10)]

    public Vector3 GFenemy001pos;
    public Vector3 GFenemy002pos;
    public Vector3 GFenemy003pos;
    public Vector3 GFenemy004pos;


    // Start is called before the first frame update
    void Start()
    {
        currentFloor = Floor.THIRD;

        TFenemy001.SetActive(true);

        SFenemy001.SetActive(false);
        SFenemy002.SetActive(false);

        FFenemy001.SetActive(false);
        FFenemy002.SetActive(false);
        FFenemy003.SetActive(false);

        GFenemy001.SetActive(false);
        GFenemy002.SetActive(false);
        GFenemy003.SetActive(false);
        GFenemy004.SetActive(false);

        RunOncePlease = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPositionY > 0 && playerPositionY <= 5)
        {
            //Ground floor
            currentFloor = Floor.GROUND;
        }
        else if (playerPositionY > 5 && playerPositionY <= 9)
        {
            //First FLoor
            currentFloor = Floor.FIRST;
        }
        else if (playerPositionY > 9 && playerPositionY <= 13)
        {
            //second FLoor
            currentFloor = Floor.SECOND;
        }
        else if (playerPositionY > 13 && playerPositionY <= 17)
        {
            //third FLoor
            currentFloor = Floor.THIRD;
        }
        //can add second "level" to final room


        /*
        if(currentFloor == Floor.GROUND)
        {
            //enable groundfloor enemies and disable other enemies (to be safe)

            

        }
        if (currentFloor == Floor.FIRST)
        {
            
        }
        if (currentFloor == Floor.SECOND)
        {
            
        }
        if (currentFloor == Floor.THIRD)
        {
            
        }*/
    }

    public void ResetGroundPos()
    {
        GFenemy001pos = new Vector3 (0, 0, 0);
        GFenemy002pos = new Vector3(0, 0, 0);
        GFenemy003pos = new Vector3(0, 0, 0);
        GFenemy004pos = new Vector3(0, 0, 0);
    }

    public void ResetFirstPos()
    {
        FFenemy001pos = new Vector3(0, 0, 0);
        FFenemy002pos = new Vector3(0, 0, 0);
        FFenemy003pos = new Vector3(0, 0, 0);
    }

    public void ResetSecondPos()
    {
        SFenemy001pos = new Vector3(0, 0, 0);
        SFenemy002pos = new Vector3(0, 0, 0);
    }

    public void ResetThirdPos()
    {
        TFenemy001pos = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GROUND")
        {
            //SecondToThird.SetActive(false);
            //currentFloor = Floor.GROUND;
            ResetFirstPos();


            TFenemy001.SetActive(false);

            SFenemy001.SetActive(false);
            SFenemy002.SetActive(false);

            FFenemy001.SetActive(false);
            FFenemy002.SetActive(false);
            FFenemy003.SetActive(false);

            GFenemy001.SetActive(true);
            GFenemy002.SetActive(true);
            GFenemy003.SetActive(true);
            GFenemy004.SetActive(true);
        }

        if (other.tag == "FIRST")
        {
            ResetGroundPos();
            ResetSecondPos();


            TFenemy001.SetActive(false);

            SFenemy001.SetActive(false);
            SFenemy002.SetActive(false);

            FFenemy001.SetActive(true);
            FFenemy002.SetActive(true);
            FFenemy003.SetActive(true);

            GFenemy001.SetActive(false);
            GFenemy002.SetActive(false);
            GFenemy003.SetActive(false);
            GFenemy004.SetActive(false);
        }
        if (other.tag == "SECOND")
        {
            ResetFirstPos();
            ResetThirdPos();

            TFenemy001.SetActive(false);

            SFenemy001.SetActive(true);
            SFenemy002.SetActive(true);

            FFenemy001.SetActive(false);
            FFenemy002.SetActive(false);
            FFenemy003.SetActive(false);

            GFenemy001.SetActive(false);
            GFenemy002.SetActive(false);
            GFenemy003.SetActive(false);
            GFenemy004.SetActive(false);
        }
        if (other.tag == "THIRD")
        {
            ResetSecondPos();

            TFenemy001.SetActive(true);

            SFenemy001.SetActive(false);
            SFenemy002.SetActive(false);

            FFenemy001.SetActive(false);
            FFenemy002.SetActive(false);
            FFenemy003.SetActive(false);

            GFenemy001.SetActive(false);
            GFenemy002.SetActive(false);
            GFenemy003.SetActive(false);
            GFenemy004.SetActive(false);
        }

    }
}

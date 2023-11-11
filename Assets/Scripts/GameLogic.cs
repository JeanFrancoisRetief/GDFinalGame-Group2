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
        THIRD,
        STAIRS
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
        //currentFloor = Floor.THIRD;

        TFenemy001.SetActive(false);

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
        playerPositionY = gameObject.transform.position.y;
        if (playerPositionY > 0.1f && playerPositionY <= 0.3f)
        {
            //Ground floor
            currentFloor = Floor.GROUND;
        }
        else if (playerPositionY > 4.3f && playerPositionY <= 4.5f)
        {
            //First FLoor
            currentFloor = Floor.FIRST;
        }
        else if (playerPositionY > 8.3f && playerPositionY <= 8.5f)
        {
            //second FLoor
            currentFloor = Floor.SECOND;
        }
        else if (playerPositionY > 12.3f && playerPositionY <= 12.5f)
        {
            //third FLoor
            currentFloor = Floor.THIRD;
        }
        else
        {
            currentFloor = Floor.STAIRS;
        }
        //can add second "level" to final room


        
        if(currentFloor == Floor.GROUND)
        {
            //enable groundfloor enemies and disable other enemies (to be safe)
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
        if (currentFloor == Floor.FIRST)
        {
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
        if (currentFloor == Floor.SECOND)
        {
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
        if (currentFloor == Floor.THIRD)
        {
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
        if (currentFloor == Floor.STAIRS)
        {
            TFenemy001.SetActive(false);

            SFenemy001.SetActive(false);
            SFenemy002.SetActive(false);

            FFenemy001.SetActive(false);
            FFenemy002.SetActive(false);
            FFenemy003.SetActive(false);

            GFenemy001.SetActive(false);
            GFenemy002.SetActive(false);
            GFenemy003.SetActive(false);
            GFenemy004.SetActive(false);

            ResetGroundPos();
            ResetFirstPos();
            ResetSecondPos();
            ResetThirdPos();

        }
    }
    
    public void ResetGroundPos()
    {
        GFenemy001pos = new Vector3 (-37.95549f, 0, 6);
        GFenemy002pos = new Vector3(-30, 0, 25);
        GFenemy003pos = new Vector3(-30, 0, 20);
        GFenemy004pos = new Vector3(-41, 0, 37);

        GFenemy001.transform.position = GFenemy001pos;
        GFenemy002.transform.position = GFenemy002pos;
        GFenemy003.transform.position = GFenemy003pos;
        GFenemy004.transform.position = GFenemy004pos;
    }

    public void ResetFirstPos()
    {
        FFenemy001pos = new Vector3(-23, 4.24f, 40);
        FFenemy002pos = new Vector3(-41, 4.24f, 15);
        FFenemy003pos = new Vector3(-46, 4.24f, 27);

        FFenemy001.transform.position = FFenemy001pos;
        FFenemy002.transform.position = FFenemy002pos;
        FFenemy003.transform.position = FFenemy003pos;
    }

    public void ResetSecondPos()
    {
        SFenemy001pos = new Vector3(-25, 8.15f, 42);
        SFenemy002pos = new Vector3(-40, 8.15f, 6);

        SFenemy001.transform.position = SFenemy001pos;
        SFenemy002.transform.position = SFenemy002pos;
    }

    public void ResetThirdPos()
    {
        TFenemy001pos = new Vector3(-40, 12.335f, 6);

        TFenemy001.transform.position = TFenemy001pos;
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GROUND")
        {
            //SecondToThird.SetActive(false);
            //currentFloor = Floor.GROUND;
            Debug.Log("Trigger");
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
            Debug.Log("Trigger");

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
            Debug.Log("Trigger");
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
            Debug.Log("Trigger");
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

    }*/
}

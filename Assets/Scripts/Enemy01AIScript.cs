using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy01AIScript : MonoBehaviour
{
    private Vector3 direction;
    private Transform target;

    [Header("Scripts")]
    public ResourceManagementScript resourceManagementScript;

    [Header("Movement")]
    public float slowdownMultiplier = 0.02f;

    //[Header("Stimulus")]
    private float viewRange = 0;
    private float hearRange = 0;
    private float staminaSenceRange = 0;
    private float powerSenceRange = 0;

    [Header("UniqueEnemies")]
    public int enemyType = 1;
    public float Enemy01Range = 0;
    public float Enemy02Range = 0;
    public float Enemy03Range = 0;
    public float Enemy04Range = 0;

    [Space(10)]
    public float Enemy01viewRange = 40;
    public float Enemy01hearRange = 0;
    public float Enemy01stamRange = 20;
    public float Enemy01powRange = 0;

    [Space(10)]
    public float Enemy02viewRange = 10;
    public float Enemy02hearRange = 10;
    public float Enemy02stamRange = 30;
    public float Enemy02powRange = 30;

    [Space(10)]
    public float Enemy03viewRange = 0;
    public float Enemy03hearRange = 45;
    public float Enemy03stamRange = 0;
    public float Enemy03powRange = 0;

    [Space(10)]
    public float Enemy04viewRange = 20;
    public float Enemy04hearRange = 20;
    public float Enemy04stamRange = 20;
    public float Enemy04powRange = 20;

    [Header("Chase")]
    public bool isChasing = false;
    public int ChaseFrameCounter = 0;
    public float chasetime = 5;



    //public Slider PlayerHealthSlider;

    //private GameObject poof;
    //public GameObject particlePoofPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //attackRange = 10;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //slowdownMultiplier = 0.02f;
        isChasing = false;
        ChaseFrameCounter = 0;

        //starting ranges
        if (enemyType == 1)
        {
            viewRange = Enemy01viewRange;
            hearRange = Enemy01hearRange;
            staminaSenceRange = Enemy01stamRange;
            powerSenceRange = Enemy01powRange;
        }
        else if (enemyType == 2)
        {
            viewRange = Enemy02viewRange;
            hearRange = Enemy02hearRange;
            staminaSenceRange = Enemy02stamRange;
            powerSenceRange = Enemy02powRange;
        }
        else if (enemyType == 3)
        {
            viewRange = Enemy03viewRange;
            hearRange = Enemy03hearRange;
            staminaSenceRange = Enemy03stamRange;
            powerSenceRange = Enemy03powRange;
        }
        else if (enemyType == 4)
        {
            viewRange = Enemy04viewRange;
            hearRange = Enemy04hearRange;
            staminaSenceRange = Enemy04stamRange;
            powerSenceRange = Enemy04powRange;
        }
        else
        {
            Debug.Log("Enemy type not selected");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move towards player
        direction = target.position - transform.position;

        //unique AI's
        if(enemyType == 1)
        {
            /*
                Deaf (can be as loud as you want)
                Great at seeing (greatest view radius) player
                Faster when viewed by player, and when stamina is HIGH
             */
            float Range;
            if (resourceManagementScript.staminaValue > 75)
            {
                Range = viewRange + staminaSenceRange;
            }
            else
            {
                Range = viewRange;
            }

            if (resourceManagementScript.sightLevel == 0)
            {
                Enemy01Range = 0;
            }
            else if(resourceManagementScript.sightLevel == 1)
            {
                Enemy01Range = Range / 2;
            }
            else if (resourceManagementScript.sightLevel == 2)
            {
                Enemy01Range = Range;
            }
            else if (resourceManagementScript.sightLevel == 3)
            {
                Enemy01Range = Range / 0.5f;
            }

            

            if (Vector3.Distance(transform.position, target.position) < Enemy01Range)
            {
                transform.Translate(direction * slowdownMultiplier);
                isChasing = true;
            }
            else
            {
                isChasing = false;
                ChaseFrameCounter = 0;
            }

        }
        if (enemyType == 2)
        {
            /*
                Freezes when player looks at it
                More active when player’s power / stamina is LOW (flashlight runs out - it will come for you)
             */
        }
        if (enemyType == 3)
        {
            /*
                Blind (won’t react to sight-level or flashlight)
                Great at hearing (greatest hearing radius) player’s movements
                Moves constantly towards sounds (player or environment)
             */
        }
        if (enemyType == 4)
        {
            /*
                More active the lower the player’s visibility is LOW (”sight” value), i.e., it will hunt you if you stick to the shadows
                Basic hearing and sight
             */
        }


        //temp movemnent (COMMENT OUT WHEN TESTING UNIQUE AI's ABOVE)
        //if (Vector3.Distance(transform.position, target.position) < viewRange)
        //{
        //    transform.Translate(direction * slowdownMultiplier);
        //    isChasing = true;
        //}

        if (isChasing)
        {
            ChaseFrameCounter++;
        }
        if(ChaseFrameCounter >= 60*chasetime)
        {
            isChasing = false;
            ChaseFrameCounter = 0;
            Destroy(gameObject);
        }

        //Attack AI
        if (Vector3.Distance(transform.position, target.position) < 1)
        {
            //Attack

            //--------
            Destroy(gameObject);
        }

    }
}

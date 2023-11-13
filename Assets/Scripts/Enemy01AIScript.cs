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
    public UIScript uiScript;
    public SoundScript soundScript;

    [Header("EnemyVisuals")]
    public GameObject Enemy01Visuals;
    public GameObject Enemy02Visuals;
    public GameObject Enemy03Visuals;
    public GameObject Enemy04Visuals;


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

    public bool isAttacking;

    [Header("Bools")]
    public bool inView;
    private bool vukAttacking;
    private bool kieranAttacking;
    private bool timAttacking;
    private bool blamboAttacking;

    //[Header("States")]
    //public int HealthState;

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
        isAttacking = false;
        ChaseFrameCounter = 0;
        uiScript.HealthState = 0; //okay

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

        inView = false;


        if(enemyType == 1)///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            Enemy01Visuals.SetActive(true);
            Enemy02Visuals.SetActive(false);
            Enemy03Visuals.SetActive(false);
            Enemy04Visuals.SetActive(false);
        }
        if(enemyType == 2)
        {
            Enemy01Visuals.SetActive(false);
            Enemy02Visuals.SetActive(true);
            Enemy03Visuals.SetActive(false);
            Enemy04Visuals.SetActive(false);
        }
        if (enemyType == 3)
        {
            Enemy01Visuals.SetActive(false);
            Enemy02Visuals.SetActive(false);
            Enemy03Visuals.SetActive(true);
            Enemy04Visuals.SetActive(false);
        }
        if (enemyType == 4)
        {
            Enemy01Visuals.SetActive(false);
            Enemy02Visuals.SetActive(false);
            Enemy03Visuals.SetActive(false);
            Enemy04Visuals.SetActive(true);
        }////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

            if (inView)
            {
                Debug.Log("Sees you");
                if (resourceManagementScript.sightLevel == 0)
                {
                    resourceManagementScript.sightLevel = 1;
                }
                else if (resourceManagementScript.sightLevel == 1)
                {
                    resourceManagementScript.sightLevel = 2;
                }
                else if (resourceManagementScript.sightLevel == 2)
                {
                    resourceManagementScript.sightLevel = 3;
                }
                else if (resourceManagementScript.sightLevel == 3)
                {
                    Enemy01Range = Range * 3 ;
                }
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

                soundScript.enemyVuk.Play();
                vukAttacking = true;
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
            float Range;
            Range = viewRange*2;
            if ((resourceManagementScript.staminaValue < 30) && (resourceManagementScript.powerLeft < 30))
            {
                Range = viewRange + staminaSenceRange + powerSenceRange;
            }
            else if(resourceManagementScript.staminaValue < 30)
            {
                Range = viewRange + staminaSenceRange;
            }
            else if (resourceManagementScript.powerLeft < 30)
            {
                Range = viewRange + powerSenceRange;
            }

            if (inView)
            {
                Enemy02Range = 0;
            }
            else
            {
                //Enemy02Range = Enemy02viewRange*2; //test
                Enemy02Range = Range;
            }

            if (Vector3.Distance(transform.position, target.position) < Enemy02Range)
            {
                transform.Translate(direction * slowdownMultiplier);
                isChasing = true;

                soundScript.enemyKieran.Play();
                kieranAttacking = true;
            }
            else
            {
                isChasing = false;
                ChaseFrameCounter = 0;
            }
        }
        if (enemyType == 3)
        {
            /*
                Blind (won’t react to sight-level or flashlight)
                Great at hearing (greatest hearing radius) player’s movements
                Moves constantly towards sounds (player or environment)
             */
            float Range;
            Range = hearRange;
            if (resourceManagementScript.noiseLevel == 0)
            {
                Enemy03Range = 0;
            }
            else if (resourceManagementScript.noiseLevel == 1)
            {
                Enemy03Range = Range/2.5f;
            }
            else if (resourceManagementScript.noiseLevel == 2)
            {
                Enemy03Range = Range/1.5f;
            }
            else if (resourceManagementScript.noiseLevel == 3)
            {
                Enemy03Range = Range;
            }
            else if (resourceManagementScript.noiseLevel == 4)
            {
                Enemy03Range = Range*1.34f;
            }
            else if (resourceManagementScript.noiseLevel == 5)
            {
                Enemy03Range = Range * 1.78f; 
            }

            if (Vector3.Distance(transform.position, target.position) < Enemy03Range)
            {
                transform.Translate(direction * slowdownMultiplier);
                isChasing = true;

                soundScript.enemyTim.Play();
                timAttacking = true;
            }
            else
            {
                isChasing = false;
                ChaseFrameCounter = 0;
            }
        }
        if (enemyType == 4)
        {
            /*
                More active the lower the player’s visibility is LOW (”sight” value), i.e., it will hunt you if you stick to the shadows
                Basic hearing and sight
             */
            float Range;
            Range = viewRange;

            if(resourceManagementScript.noiseLevel == 1)
            {
                Range = viewRange + hearRange/2.5f;
            }
            else if (resourceManagementScript.noiseLevel == 2)
            {
                Range = viewRange + hearRange / 2;
            }
            else if (resourceManagementScript.noiseLevel == 3)
            {
                Range = viewRange + hearRange / 1.5f;
            }
            else if (resourceManagementScript.noiseLevel == 4)
            {
                Range = viewRange + hearRange;
            }
            else if (resourceManagementScript.noiseLevel == 5)
            {
                Range = viewRange + hearRange *2;
            }

            if (resourceManagementScript.sightLevel == 2) //reverse of enemy 1
            {
                Enemy04Range = 0;
            }
            else if (resourceManagementScript.sightLevel == 1)
            {
                Enemy04Range = Range / 2.5f;
            }
            else if (resourceManagementScript.sightLevel == 0)
            {
                Enemy04Range = Range;
            }
            

            if (Vector3.Distance(transform.position, target.position) < Enemy04Range)
            {
                transform.Translate(direction * slowdownMultiplier);
                isChasing = true;

                soundScript.enemyBlambo.Play();
                blamboAttacking = true;
            }
            else
            {
                isChasing = false;
                ChaseFrameCounter = 0;
            }
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
            //Destroy(gameObject);
            gameObject.transform.position = new Vector3(0, 100000000, 0);
        }

        //Attack AI
        if (Vector3.Distance(transform.position, target.position) < 1)
        {
            //Attack
            isAttacking = true;
            //--------
            //Destroy(gameObject);
            gameObject.transform.position = new Vector3(0, 100000000, 0);
        }
        else
        {
            isAttacking = false;
        }

        //Attacking player
        if (isAttacking == true)
        {
            uiScript.HealthState++;
            soundScript.gettingHit.Play();
            isAttacking = false;
        }

        if (vukAttacking)
        {
            StartCoroutine(vukSound());
        }

        if (kieranAttacking)
        {
            StartCoroutine(kieranSound());
        }

        if (timAttacking)
        {
            StartCoroutine(timSound());
        }

        if (blamboAttacking)
        {
            StartCoroutine(blamboSound());
        }
    }

    public IEnumerator vukSound()
    {
        yield return new WaitForSeconds(5f);

        vukAttacking = false;
    }

    public IEnumerator kieranSound()
    {
        yield return new WaitForSeconds(5f);

        kieranAttacking = false;
    }

    public IEnumerator timSound()
    {
        yield return new WaitForSeconds(7f);

        timAttacking = false;
    }

    public IEnumerator blamboSound()
    {
        yield return new WaitForSeconds(9f);

        blamboAttacking = false;
    }

    void OnBecameVisible()
    {
        inView = true;
    }

    void OnBecameInvisible()
    {
        inView = false;
    }
}

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



    //public Slider PlayerHealthSlider;

    //private GameObject poof;
    //public GameObject particlePoofPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //attackRange = 10;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //slowdownMultiplier = 0.02f;

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
            
        }
        if (enemyType == 2)
        {

        }
        if (enemyType == 3)
        {

        }
        if (enemyType == 4)
        {

        }


        //temp movemnent (COMMENT OUT WHEN TESTING UNIQUE AI's ABOVE)
        if (Vector3.Distance(transform.position, target.position) < viewRange)
        {
            transform.Translate(direction * slowdownMultiplier);
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

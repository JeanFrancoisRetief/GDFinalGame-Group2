using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [Header("Panels")]
    public GameObject ResourcesApp;
    public GameObject TextingApp;
    public GameObject PowerApp;

    // Start is called before the first frame update
    void Start()
    {
        ResourcesApp.SetActive(false);
        TextingApp.SetActive(false);
        PowerApp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResourcesApp.SetActive(true);
            TextingApp.SetActive(false);
            PowerApp.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ResourcesApp.SetActive(false);
            TextingApp.SetActive(true);
            PowerApp.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            ResourcesApp.SetActive(false);
            TextingApp.SetActive(false);
            PowerApp.SetActive(true);
        }
    }
}

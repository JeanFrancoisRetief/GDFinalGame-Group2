using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject pnlMain;
    public GameObject pnlControls;

    private void Start()
    {
        pnlMain.SetActive(true);
        pnlControls.SetActive(false);
    }

    private void Update()
    {
        if (pnlMain.active)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("P");

                SceneManager.LoadScene("KaiScene");
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("C");
                SceneManager.LoadScene("Credits");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (pnlControls.active)
            {
                pnlControls.SetActive(false);
                pnlMain.SetActive(true);
            }
            else
            {
                pnlMain.SetActive(false);
                pnlControls.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject pnlMain;
    public GameObject pnlCredits;
    public GameObject pnlControls;

    private void Start()
    {
        pnlMain.SetActive(true);
        pnlCredits.SetActive(false);
        pnlControls.SetActive(false);
    }

    private void Update()
    {
        if (pnlMain.active)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("P");

                SceneManager.LoadScene("GameScene");
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("C");

                pnlCredits.SetActive(true);
                //pnlControls.SetActive(false);
                //pnlMain.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("B");

                pnlControls.SetActive(true);
                //pnlCredits.SetActive(false);
                //pnlMain.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (pnlCredits.active)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                pnlCredits.SetActive(false);
                pnlControls.SetActive(false);
                pnlMain.SetActive(true);
            }
        }

        if (pnlControls.active)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                pnlControls.SetActive(false);
                pnlCredits.SetActive(false);
                pnlMain.SetActive(true);
            }
        }
    }
}

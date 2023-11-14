using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public GameObject CreditsText;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C");
            SceneManager.LoadScene("MainMenu");
        }

        CreditsText.transform.Translate(Vector3.up/5);

    }


}

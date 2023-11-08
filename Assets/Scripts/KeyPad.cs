using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyPad : MonoBehaviour
{
    public GameObject keypad;
    public Text text;
    public string answer;
    public bool checking;

    ///add all audio back in later
    //public AudioSource button;
    //public AudioSource right;
    //public AudioSource wrong;

    private void Start()
    {
        text.text = "";
        checking = false;
    }

    private void Update()
    {
        if (keypad.active)
        {
            if (checking == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Enter");
                    checking = true;
                    StartCoroutine(resetChecking());

                    if (text.text == answer)
                    {
                        StartCoroutine(RightCode());

                    }
                    else
                    {
                        StartCoroutine(WrongCode());
                    }
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    text.text = "";
                }

                #region Numbers

                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    text.text += 1.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad2))
                {
                    text.text += 2.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad3))
                {
                    text.text += 3.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad4))
                {
                    text.text += 4.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad5))
                {
                    text.text += 5.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad6))
                {
                    text.text += 6.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad7))
                {
                    text.text += 7.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad8))
                {
                    text.text += 8.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad9))
                {
                    text.text += 9.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    text.text += 0.ToString();
                }

                #endregion
            }
        }
    }

    public IEnumerator resetChecking()
    {
        yield return new WaitForSeconds(3f);

        checking = false;
    }

    public IEnumerator RightCode()
    {
        //right.Play();
        text.text = "Right";

        yield return new WaitForSeconds(2f);

        keypad.SetActive(false);
    }

    public IEnumerator WrongCode()
    {
        //wrong.Play();
        text.text = "Wrong";

        yield return new WaitForSeconds(2f);

        text.text = "";
    }
}

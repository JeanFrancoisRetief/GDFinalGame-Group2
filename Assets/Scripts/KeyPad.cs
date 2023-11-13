using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class KeyPad : MonoBehaviour
{
    public SoundScript soundScript;
    public GameObject keypad;
    public Text text;
    public string answer;
    public bool checking;

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
                    soundScript.buttonClick.Play();
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
                    soundScript.buttonClick.Play();
                    text.text = "";
                }

                #region Numbers

                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    text.text += 1.ToString();
                    soundScript.buttonClick.Play();
                }

                if (Input.GetKeyDown(KeyCode.Keypad2))
                {
                    soundScript.buttonClick.Play();
                    text.text += 2.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad3))
                {
                    soundScript.buttonClick.Play();
                    text.text += 3.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad4))
                {
                    soundScript.buttonClick.Play();
                    text.text += 4.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad5))
                {
                    soundScript.buttonClick.Play();
                    text.text += 5.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad6))
                {
                    soundScript.buttonClick.Play();
                    text.text += 6.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad7))
                {
                    soundScript.buttonClick.Play();
                    text.text += 7.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad8))
                {
                    soundScript.buttonClick.Play();
                    text.text += 8.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad9))
                {
                    soundScript.buttonClick.Play();
                    text.text += 9.ToString();
                }

                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    soundScript.buttonClick.Play();
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
        soundScript.rightAnswer.Play();
        text.text = "Right";

        yield return new WaitForSeconds(2f);

        keypad.SetActive(false);

        SceneManager.LoadScene("BasementScene");
    }

    public IEnumerator WrongCode()
    {
        soundScript.wrongAnswer.Play();
        text.text = "Wrong";

        yield return new WaitForSeconds(2f);

        text.text = "";
    }
}

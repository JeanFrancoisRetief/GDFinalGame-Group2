using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [Header("Enemy Sounds")]
    public AudioSource enemyBlambo;
    public AudioSource enemyVuk;
    public AudioSource enemyTim;
    public AudioSource enemyKieran;

    [Header("Environment Sounds")]
    public AudioSource floorAmbience;
    public AudioSource floorAmbience2;
    public AudioSource stairsAmbience;
    public AudioSource chargePhone;
    public AudioSource doorOpen;
    public AudioSource keys;

    public int environmentalNoisesCounter;
    public int randomCounter;

    [Header("Keypad Sounds")]
    public AudioSource rightAnswer;
    public AudioSource wrongAnswer;
    public AudioSource buttonClick;

    [Header("Player Sounds")]
    public AudioSource gettingHit;
    public AudioSource lowStamina;
    public AudioSource walking;
    public AudioSource running;
    public AudioSource flashlight;
    public AudioSource textNotification;

    private void Update()
    {
        environmentalNoisesCounter++;
        if (environmentalNoisesCounter == 60)
        {
            CheckRandomCounter();
            environmentalNoisesCounter = 0;
        }
    }

    public void CheckRandomCounter()
    {
        randomCounter = UnityEngine.Random.Range(0, 100);

        if (randomCounter == 50)
        {
            floorAmbience.Play();
        }

        if (randomCounter == 100)
        {
            floorAmbience2.Play();
        }
    }
}

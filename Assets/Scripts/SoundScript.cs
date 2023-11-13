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
    public AudioSource stairsAmbience;
    public AudioSource chargePhone;
    public AudioSource doorOpen;
    public AudioSource keys;

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
}

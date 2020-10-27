/*
 * Chris Smith
 * Assignment 6
 * Script to manage UI elements
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Timer
    public float timer = 30f;
    public Text timerText;

    //Tutorial
    public Text moveTut;
    public Text goalTut;

    //Game State
    public Text winText;
    public Text loseText;

    //Health
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "Time: " + timer;
        healthText.text = "Health: ";

        winText.enabled = false;
        loseText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Countdown the timer
        timer -= Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("f0");
        if (timer <= 0)
        {
            winText.enabled = true;
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.ReturnToMenu();
            }
        }
    }
}

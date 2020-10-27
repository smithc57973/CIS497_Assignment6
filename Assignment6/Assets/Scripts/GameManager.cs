/*
 * Chris Smith
 * Assignment 6
 * Script to manage game state
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //Vars
    public GameObject pauseMenu;
    public string currentScene = string.Empty;

    //Load a scene
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        Time.timeScale = 1f;
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level");
            return;
        }
        currentScene = levelName;
    }

    //Unload a scene
    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to unload level");
            return;
        }
    }

    //Activate pause menu
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    //Deactivate pause menu
    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        //Press P to pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        //After 5 seconds center walls will be destroyed
        StartCoroutine(destroyWalls());
    }

    //Accessory unload
    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentScene);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to unload level");
            return;
        }
    }

    //Reset scenes back to main menu
    public void ReturnToMenu()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1f;
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level");
            return;
        }
    }

    //After 5 seconds center walls will be destroyed
    public IEnumerator destroyWalls()
    {
        yield return new WaitForSeconds(5);
        GameObject.FindGameObjectWithTag("Center").SetActive(false);
        yield return new WaitForSeconds(25);
        GameObject.FindGameObjectWithTag("Center").SetActive(true);
    }

    /*
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second instance of singleton game manager.");
        }
    }
    */
}

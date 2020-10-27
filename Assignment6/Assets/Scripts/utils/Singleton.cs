/*
 * Chris Smith
 * Assignment 6
 * Script for making an object a singleton
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of singleton class");
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void onDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}

﻿/*
 * Chris Smith
 * Assignment 6
 * Script to manage golem type enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    //protected override void Attack(int dmg)
    //{
    //    Debug.Log("Golem attacks!");
    //}

    protected override void Awake()
    {
        base.Awake();
    }

    //public override void TakeDamage(int amount)
    //{
    //    Debug.Log("You took " + amount + " damage.");
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

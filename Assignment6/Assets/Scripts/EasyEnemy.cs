/*
 * Chris Smith
 * Assignment 6
 * Script to manage the easy enemy type
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

}

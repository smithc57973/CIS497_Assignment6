﻿/*
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
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        gameObject.transform.localScale = new Vector3(3, 3, 3);
        weapon.dmgBonus = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

}

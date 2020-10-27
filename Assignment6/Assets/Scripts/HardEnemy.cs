/*
 * Chris Smith
 * Assignment 6
 * Script to manage the hard enemy type
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        //Set specific properties
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        weapon.dmgBonus = 3;
        speed = 12f;
    }
}

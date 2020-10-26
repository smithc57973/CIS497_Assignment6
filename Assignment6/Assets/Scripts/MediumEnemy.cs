/*
 * Chris Smith
 * Assignment 6
 * Script to manage the medium enemy type
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        gameObject.transform.localScale = new Vector3(2, 2, 2);
        weapon.dmgBonus = 2;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}

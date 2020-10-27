/*
 * Chris Smith
 * Assignment 6
 * Script to manage weapons
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Weapon vars
    public int dmgBonus;
    public Enemy enemyHoldingWeapon;

    private void Awake()
    {
        //Get enemy using polymorphism
        enemyHoldingWeapon = gameObject.GetComponent<Enemy>();
        //EnemyEatsWeapon(enemyHoldingWeapon);
    }

    //Tutorial function
    protected void EnemyEatsWeapon(Enemy enemy)
    {
        Debug.Log("Enemy eats weapon");
    }

    //Tutorial function
    public void Recharge()
    {
        Debug.Log("Recharging Weapon.");
    }
}

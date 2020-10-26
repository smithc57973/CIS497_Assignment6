/*
 * Chris Smith
 * Assignment 6
 * Script to manage enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //Enemy attributes
    protected float speed;
    protected int damage;
    [SerializeField] protected Weapon weapon;

    protected virtual void Awake()
    {
        speed = 5f;
        weapon = gameObject.AddComponent<Weapon>();
    }
    
}

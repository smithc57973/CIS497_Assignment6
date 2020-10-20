/*
 * Chris Smith
 * Assignment 6
 * Script to manage enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    //Enemy attributes
    protected float speed;
    protected int health;
    [SerializeField] protected Weapon weapon;

    protected virtual void Awake()
    {
        speed = 5f;
        health = 100;
        weapon = gameObject.AddComponent<Weapon>();
    }

    protected abstract void Attack(int dmg);
    public abstract void TakeDamage(int amount);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

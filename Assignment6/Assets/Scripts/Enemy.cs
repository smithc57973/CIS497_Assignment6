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
    //Map boundaries
    public int lBound = -420;
    public int rBound = -302;
    public int tBound = 565;
    public int bBound = 497;

    //Enemy attributes
    protected float speed;
    [SerializeField] protected Weapon weapon;
    [SerializeField] protected Player player;

    //Reference to Rigidbody
    public Rigidbody rb;

    protected virtual void Awake()
    {
        speed = 20f;
        weapon = gameObject.AddComponent<Weapon>();
        player = GameObject.FindObjectOfType<Player>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce((player.transform.position - transform.position).normalized * speed);
        transform.LookAt(player.transform);
        rb.AddRelativeForce(0, 0, speed);

        //Keep the enemy in bounds
        if (gameObject.transform.position.x < bBound)
        {
            gameObject.transform.position = new Vector3(bBound, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x > tBound)
        {
            gameObject.transform.position = new Vector3(tBound, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.z < lBound)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, lBound);
        }
        if (gameObject.transform.position.z > rBound)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, rBound);
        }
    }

}

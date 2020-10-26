/*
 * Chris Smith
 * Assignment 6
 * Script to manage player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    //Map boundaries
    public int lBound = -423;
    public int rBound = -300;
    public int tBound = 565;
    public int bBound = 497;

    //Player vars
    public float speed;
    public int health;

    // Start is called before the first frame update
    public void Awake()
    {
        speed = 20f;
        health = 3;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Create movement vector
        Vector3 move = transform.right * -z + transform.forward * x;
        //Apply move
        gameObject.transform.Translate(move * speed * Time.deltaTime);

        //Keep the player in bounds
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

        //Return to main menu if die
        if (health <= 0)
        {
            GameManager.Instance.LoadLevel("MainMenu");
        }
    }

    public void onCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            int dmg = other.gameObject.GetComponent<Weapon>().dmgBonus;
            TakeDamage(dmg);
        }
    }

}

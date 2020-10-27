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
    public int lBound = -420;
    public int rBound = -302;
    public int tBound = 565;
    public int bBound = 497;

    //Player vars
    public float speed;
    public int health;

    //Reference to UI
    public UIManager uiManager;

    //Reference to Rigidbody
    public Rigidbody rb;

    // Start is called before the first frame update
    public void Awake()
    {
        speed = 20f;
        health = 3;
        uiManager = GameObject.FindObjectOfType<UIManager>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //Take damage from interface
    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Create movement vector
        Vector3 move = transform.right * -z + transform.forward * x;
        //Apply move
        rb.AddForce(move * speed, ForceMode.Force);

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

        //Display current health
        uiManager.healthText.text = "Health: " + health;
        
    }

    void Update()
    {
        //Return if dead
        if (health <= 0)
        {
            uiManager.loseText.enabled = true;
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.ReturnToMenu();
            }

        }
    }

    //Collision event from enemies
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            int dmg = other.gameObject.GetComponent<Weapon>().dmgBonus;
            TakeDamage(dmg);
        }
    }
}

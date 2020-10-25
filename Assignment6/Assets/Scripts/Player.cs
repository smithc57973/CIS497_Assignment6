using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enemy
{
    public override void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    protected override void Attack(int dmg)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        speed = 20f;
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
            
    }
}

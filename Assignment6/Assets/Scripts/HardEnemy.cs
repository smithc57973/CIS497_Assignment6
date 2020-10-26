using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        weapon.dmgBonus = 3;
        speed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}

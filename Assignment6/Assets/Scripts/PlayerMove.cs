using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Player move speed
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameOver == false)
        {
            //Get movement input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            //Create movement vector
            Vector3 move = transform.right * z + transform.forward * x;
            //Apply move
            //controller.Move(move * speed * Time.deltaTime);
            gameObject.transform.Translate(move);

        }
    }
}

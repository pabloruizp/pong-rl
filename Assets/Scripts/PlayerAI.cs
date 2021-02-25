using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Transform tf;
    public Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    void Move(Vector2 direction){
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction;
        float distance = ball.position.y - tf.position.y;

        if(tf.position.y > ball.position.y) {
            direction = new Vector2(0, distance < 1 ? distance : 1);
        } else {
            direction = new Vector2(0, distance > -1 ? distance : -1);
        }
        Move(direction); 
    }
}

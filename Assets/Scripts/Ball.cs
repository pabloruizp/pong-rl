using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform tf;
    public float speed = 20;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    public void Reset() {
        tf.position = new Vector2(0,0);
        rb.velocity = new Vector2(0,0);
        rb.AddForce(new Vector2(40, 0));
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "P1") {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            rb.velocity = dir * speed;
        }

        if (col.gameObject.name == "P2") {
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            rb.velocity = dir * speed;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

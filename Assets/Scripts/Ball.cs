using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Ball : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform tf;
    public float speed = 20;
    public Agent agent;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    public void Reset() {
        tf.position = new Vector2(0,0);
        rb.velocity = new Vector2(0,0);

        int[] direction = {40, -40};

        rb.AddForce(new Vector2(direction[Random.Range(0, 2)], Random.Range(-10, 10)));
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "P1" || col.gameObject.name == "Agent") {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            rb.velocity = dir * speed;
            agent.AddReward(0.1f);
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

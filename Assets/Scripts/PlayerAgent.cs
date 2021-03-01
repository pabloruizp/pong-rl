using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class PlayerAgent : Agent
{
    public float speed = 10f;
    private Rigidbody2D rb;

    public int nRay = 10;

    private RaycastHit2D[] hits;
    
    public void Eyes() {
        float degrees = 360 / nRay;

        for(int i=0; i < nRay; i++) {
            hits[i] = Physics2D.Raycast(rb.position, new Vector2(Mathf.Cos(i*degrees * Mathf.Deg2Rad), Mathf.Sin(i*degrees * Mathf.Deg2Rad)), Mathf.Infinity, 768);
            Debug.DrawRay(rb.position, new Vector2(Mathf.Cos(i*degrees * Mathf.Deg2Rad), Mathf.Sin(i*degrees * Mathf.Deg2Rad)) * hits[i].distance, Color.red);
        }
    }
    
    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        hits = new RaycastHit2D[nRay];
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        float degrees = 360 / nRay;

        for(int i=0; i < nRay; i++) {
            sensor.AddObservation(Physics2D.Raycast(rb.position, new Vector2(Mathf.Cos(i*degrees * Mathf.Deg2Rad), Mathf.Sin(i*degrees * Mathf.Deg2Rad)), Mathf.Infinity, 768));
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        Move(new Vector2(0, vectorAction[0])); 
    }

    public override void OnEpisodeBegin()
    {
        rb.MovePosition(new Vector2(rb.position.x, 0));
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Vertical");
    }

    void Move(Vector2 direction){
        rb.velocity = direction * speed;
        AddReward(-0.001f);
    }

}

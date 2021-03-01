using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Goal : MonoBehaviour
{
    public GameController gc;
    public bool player;

    public Agent agent;
    // Start is called before the first frame update


    void OnTriggerEnter2D(Collider2D col) {
        gc.Score(player);
        if(player) {
            agent.AddReward(-1);
            agent.EndEpisode();
        } else {
            agent.AddReward(1);
        }
    }


}

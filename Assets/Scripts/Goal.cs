using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameController gc;
    public bool player;
    // Start is called before the first frame update


    void OnTriggerEnter2D(Collider2D col) {
        gc.Score(player);
    }


}

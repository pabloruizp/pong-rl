using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int ScoreP1;
    public int ScoreP2;
    public Text ScoreP1Text;
    public Text ScoreP2Text;
    public Ball ball;

    private bool Text = false;
    // Start is called before the first frame update
    void Start()
    {
        this.Reset();
    }

    void Reset() {
        ScoreP1 = 0;
        ScoreP2 = 0;
        if(Text) {
            ScoreP1Text.text = ScoreP1.ToString();
            ScoreP2Text.text = ScoreP2.ToString();
        }
        ball.Reset();
    }
    public void Score(bool player) {
        if(!player) {
            ScoreP1++;
            if(Text) {
                ScoreP1Text.text = ScoreP1.ToString();
            }
        } else {
            ScoreP2++;
            if(Text) {
                ScoreP2Text.text = ScoreP2.ToString();
            }
        }
        ball.Reset();
    }
}

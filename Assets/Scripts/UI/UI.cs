using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text PlayerCollisionText;
    public Text LoseCollisionText;
    public Ball ball;
    
 
    // Update is called once per frame
    void Update()
    {
        int counterPlayer = ball.CounterCollisionPlayer();
        int counterLose = ball.CounterCollisionLoze();
        PlayerCollisionText.text = "Столкновений с играком: " + counterPlayer.ToString();
        LoseCollisionText.text = "Проигрыши: " + counterLose.ToString();
    }
}

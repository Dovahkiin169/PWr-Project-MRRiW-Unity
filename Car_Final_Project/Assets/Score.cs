using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score.ToString();
    }

    public void increaseScore(int howMuch)
    {
        score += 1;
        scoreText.text = "Score : " + score.ToString();
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = "Score : " + score.ToString();
    }
    
    public int getScore()
    {
        return 1;
    }
}

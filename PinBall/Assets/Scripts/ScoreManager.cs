using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int score = 0;
    public static int newScore = 0;
    public static string scoreText = "";
    public TextMesh display;
    public TextMesh displayNew;

    private void Update()
    {
        display.text = "SCORE:" + score.ToString("D7");
        if (newScore != 0)
        {
            displayNew.text = scoreText + "\n"+newScore.ToString();
            newScore = 0;
            Invoke("ResetScore", 2.0f);

        }
        else
        {
        }
    }
    void OnGUI()    
    {
        //GUILayout.Label("Score:" + score.ToString());
        //GetComponent<ScoreText>().Text = score.ToString();
    }

    private void Start()
    {
        displayNew.text = "";
    }

    void ResetScore()
    {
        displayNew.text = "";
    }

}

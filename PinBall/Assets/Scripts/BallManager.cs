using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour {

    public GameObject ball;
    public Transform spawnPosition;
    public static int lives = 1;
    public TextMesh display;
    public bool gameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameObject.FindGameObjectWithTag("Ball"))
        {
            if (lives > 0)
            {
                lives--;
                Instantiate(ball, spawnPosition.position, ball.transform.rotation);
                if (display)
                {
                    display.text = "BALLS:" + lives.ToString();
                }
            }
            else
            {
                if (display)
                {
                    display.text = "Game Over  \n(Press R to restart)";
                    gameOver = true;
                }
            }
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene(1);
//                SceneManager.LoadScene("Main");
                lives = 3;
                ScoreManager.score = 0;
                ScoreManager.newScore = 0;
                ScoreManager.scoreText = "New Game";
            }
        }
	}
}

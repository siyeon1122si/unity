using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    public int score = 0;

    public bool isGameOver = default;

    public Text bestScoreText;

    public GameObject gameoverui;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        scoreText.text = string.Format("SCORE : {0}",score);

        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("SCORE : {0}", score);

        if ( Input.GetKeyUp(KeyCode.R) )
        {
            SceneManager.LoadScene("GameScenes");
        }

        if ( score >= 500 )
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver=true;
        gameoverui.SetActive(true);

        float bestScore = 0;

        if ( bestScore < score)
        {
            bestScore = score;
        }

        bestScoreText.text = string.Format("BEST SCORE : {0}", bestScore);

        Time.timeScale = 0;
    }
}

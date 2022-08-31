using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    //public static bool save; //static can be accessed in other script
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text highScoreTxt;

    public static int score = 0;
    public static int highScore = 0;
        
    // Start is called before the first frame update
    void Start()
    {   
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreTxt.text = "Score: " + score.ToString();
        highScoreTxt.text = "High Score: " + highScore.ToString();
        //save = false;
        //score = PlayerPrefs.GetInt("totalScore");
    }

    // Update is called once per frame
    void Update()
    {   
        scoreTxt.text = score.ToString();
        //highScore = PlayerPrefs.GetInt("highscore", 0);
        //PlayerPrefs.SetInt("highscore", score);
        //saveScore();
        if(highScore > score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("gems") == true)
        {
            score += 1;
            Destroy(col.gameObject);
            /*if(highScore > score)
            {
                PlayerPrefs.SetInt("highscore", score);
            }*/
            
        }
    }

    /*private void saveScore()
    {
        if (save == true)
        {
            PlayerPrefs.SetInt("totalScore", score);
            PlayerPrefs.Save();
        }
    }*/
}


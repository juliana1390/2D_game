using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public static bool save; //static can be accessed in other script
    public Text scoreTxt;

    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        save = false;
        score = PlayerPrefs.GetInt("totalScore");
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
        saveScore();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("gems") == true)
        {
            score += 1;
            Destroy(col.gameObject);
        }
    }

    private void saveScore()
    {
        if (save == true)
        {
            PlayerPrefs.SetInt("totalScore", score);
            PlayerPrefs.Save();
        }
    }
}

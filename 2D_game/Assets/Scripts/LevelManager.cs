using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;
    void Update()
    {
        for (int i = 0; i < buttons.Length; i++) // unlock level
        {
            if (i + 2 > PlayerPrefs.GetInt("completedFase"))
            {
                buttons[i].interactable = false;
            }
        } 
    }
    /*public void callLevels()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("atualFase") + 1);
    }*/
}

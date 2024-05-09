using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    public Text scoreText;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
       
    }

    void LoadScore()
    {
        scoreText.text = "Points: " + score.ToString();
    }


    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadInicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void LoadMuerte()
    {
        SceneManager.LoadScene("Muerte");
    }

    public void LoadRanking()
    {
        SceneManager.LoadScene("Ranking");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

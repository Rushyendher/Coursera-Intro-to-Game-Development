using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

    private int countScore;
    private static GameManager _instance = null;

    public Text scoreText;
    public Text finalScoreText;
    public GameObject canvas;
    public GameObject levelBeatCanvas;

    private AudioSource audio;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return _instance;
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        canvas.SetActive(false);
        countScore = 0;
    }

    public void DisplayScore()
    {
        countScore++;
        scoreText.text = countScore.ToString();
        if(countScore >= 5)
        {
            if (audio != null)
            {
                audio.Play();
            }
            
            Invoke("WaitForLevelBeat", 2);
        }
    }

    public void WaitForLevelBeat()
    {
        if(levelBeatCanvas != null)
        {
            levelBeatCanvas.SetActive(true);
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GameOver()
    {
        finalScoreText.text = countScore.ToString();
        canvas.SetActive(true);
        scoreText.text = "";
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager gameManagerInstance;

	public int score 				= 0;
	public bool canBeatLevel		= false;
	public int beatLevelScore 		= 0;
	public float startTime 			= 10.0f;
	public Text mainScoreDisplay;
	public Text mainTimerDisplay;
	public GameObject gameOverScoreOutline;
	public AudioSource musicAudioSource;
	public bool isGameOver 			= false;
	public GameObject playAgainButton;
	public string playAgainLevelToLoad;
	public GameObject nextLevelButton;
	public string nextLevelToLoad;


	private float currentTime;
	// Use this for initialization
	void Start ()
	{
		currentTime = startTime;
		score = 0;
		if (gameManagerInstance == null) {
			gameManagerInstance = gameObject.GetComponent<GameManager> ();
		}
		mainScoreDisplay.text = "0";

		if (playAgainButton) {
			playAgainButton.SetActive (false);
		}
		if (nextLevelButton) {
			nextLevelButton.SetActive (false);
		}
		if (gameOverScoreOutline) {
			gameOverScoreOutline.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isGameOver)
		{
			if (canBeatLevel && (score >= beatLevelScore)) 
			{
				BeatLevel ();
			} 
			else if (currentTime < 0.00f) 
			{
				EndGame ();
			} 
			else 
			{
				currentTime -= Time.deltaTime;
				if (currentTime <= 5.0f) {
					mainTimerDisplay.GetComponent<Text> ().color = Color.red;

				} else {
					mainTimerDisplay.GetComponent<Text> ().color = Color.white;
				}

				mainTimerDisplay.text = currentTime.ToString ("0.00");
			}
		}
	}

	void BeatLevel()
	{
		isGameOver = true;
		mainTimerDisplay.text = "Level Complete";
		if (gameOverScoreOutline) {
			gameOverScoreOutline.SetActive (true);
		}
		if (nextLevelButton) {
			nextLevelButton.SetActive (true);
		}
	}

	void EndGame()
	{
		isGameOver = true;
		mainTimerDisplay.text = "GAME OVER";

		if (gameOverScoreOutline) {
			gameOverScoreOutline.SetActive (true);
		}
		if (playAgainButton) {
			playAgainButton.SetActive (true);
		}
	}

	public void TargetHit(int bonusScore,float bonusTime)
	{
		score += bonusScore;
		mainScoreDisplay.text = score.ToString ();

		currentTime += bonusTime;
		if (currentTime < 0.0f) {
			currentTime = 0.0f;
		}

		if (score >= beatLevelScore) {
			canBeatLevel = true;
		}

		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (playAgainLevelToLoad);
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene (nextLevelToLoad);
	}
}

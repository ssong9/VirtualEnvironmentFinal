using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject ball;
	public Vector3 spawnValues;
	public int ballCount;
	public float startWait;
	public float spawnWait;

	public TextMesh scoreText;
	public TextMesh restartText;
	public TextMesh gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene("Main");
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
			for (int i = 0; i < ballCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = //Quaternion.identity;
				Instantiate (ball, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
		GameOver();

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
			}
	
	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void subtractScore(int newScoreValue)
	{
		score -= newScoreValue;
		UpdateScore();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		scoreText.text = "Final Score: " + score;
		gameOver = true;
	}
}
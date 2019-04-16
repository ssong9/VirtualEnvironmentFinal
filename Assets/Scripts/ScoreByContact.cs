using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
		public int scoreValue;
		public float lifetime;

		private GameController gameController;

		void Start ()
		{
			GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
			if (gameControllerObject != null)
			{
				gameController = gameControllerObject.GetComponent <GameController>();
			}
			if (gameController == null)
			{
				Debug.Log ("Cannot find 'GameController' script");
			}
		}

		void OnTriggerEnter (Collider other)
		{
		if (other.CompareTag("Kill_Plane"))
			{
				Destroy(gameObject);
			}
			if (other.CompareTag("Platform"))
			{
				gameController.subtractScore(scoreValue);
			}
			if (other.CompareTag("Plane"))
			{
				gameController.addScore(scoreValue);
			}
			Destroy(gameObject, lifetime);

		}
}
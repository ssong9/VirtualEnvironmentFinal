using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreByContact : MonoBehaviour
{
		public int scoreValue;
		public float lifetime;

		private bool bounced;

		private GameController gameController;

		void Start ()
		{
			bounced = false;
			GameObject gameControllerObject = GameObject.FindWithTag("GameController");
			if (gameControllerObject != null)
			{
				gameController = gameControllerObject.GetComponent<GameController>();
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
				if (other.CompareTag("Platform") && !bounced)
				{
					gameController.subtractScore(scoreValue);
					bounced = true;
				}
				if (other.CompareTag("Plane") && !bounced)
				{
					gameController.addScore(scoreValue);
					bounced = true;
				}
				Destroy(gameObject, lifetime);

		}
}
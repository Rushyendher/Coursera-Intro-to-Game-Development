using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag.Equals ("Projectile")) {
			GameManager.gameManagerInstance.RestartGame ();
		}
	}
}

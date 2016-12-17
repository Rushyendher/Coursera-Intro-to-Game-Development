using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag.Equals ("Projectile")) {
			GameManager.gameManagerInstance.LoadNextLevel ();	
		}
	}
}

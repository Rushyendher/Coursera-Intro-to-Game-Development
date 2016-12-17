using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

	public int targetHitScore = 0;
	public float targetHitTime = 0.0f;

	public GameObject explosionPrefab;

	void OnCollisionEnter(Collision other)
	{
		if (GameManager.gameManagerInstance.isGameOver)
		{	
			return;
		}

		if (other.gameObject.tag.Equals ("Projectile"))
		{
			if (explosionPrefab) 
			{
				Instantiate (explosionPrefab,transform.position,Quaternion.identity);	
			}	

			GameManager.gameManagerInstance.TargetHit (targetHitScore,targetHitTime);
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}

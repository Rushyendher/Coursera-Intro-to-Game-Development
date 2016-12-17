using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public float projectileSpeed = 10.0f;

	public AudioClip shootClip;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown ("Fire1")) 
		{
			GameObject newProjectile = Instantiate (projectile, transform.position + transform.forward, transform.rotation) as GameObject;
			if (!newProjectile.GetComponent<Rigidbody> ()) 
			{
				newProjectile.AddComponent<Rigidbody>();
			}
			newProjectile.GetComponent<Rigidbody> ().AddForce (transform.forward * projectileSpeed,ForceMode.VelocityChange);

			if (shootClip) 
			{
				AudioSource projectileAudio = newProjectile.GetComponent<AudioSource> ();
				if (projectileAudio) {
					projectileAudio.PlayOneShot (shootClip);
				}
				else 
				{
					AudioSource.PlayClipAtPoint (shootClip,newProjectile.transform.position);	
				}
			}
		}
	}
}

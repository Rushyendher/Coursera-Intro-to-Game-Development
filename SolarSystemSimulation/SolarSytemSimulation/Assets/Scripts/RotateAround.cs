using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public Transform target;
	public int speed = 10;
	// Use this for initialization
	void Start () {
		if (target == null) {
			target = this.gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (target.transform.position, target.transform.up, speed * Time.deltaTime);
	}
}

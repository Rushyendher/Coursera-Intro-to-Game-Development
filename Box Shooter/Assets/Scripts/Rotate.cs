using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float rotationSpeed = 10.0f;

	private Transform myTransform;
	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.Rotate (Vector3.up,rotationSpeed * Time.deltaTime);
	}
}

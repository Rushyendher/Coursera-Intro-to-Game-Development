using UnityEngine;
using System.Collections;

public class RotatePickups : MonoBehaviour {

    public float rotationSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 25 * Time.deltaTime* rotationSpeed);
	}
}

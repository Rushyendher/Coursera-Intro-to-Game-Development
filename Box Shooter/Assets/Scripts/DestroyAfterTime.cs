using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float time = 2.0f;
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, time);
	}
}

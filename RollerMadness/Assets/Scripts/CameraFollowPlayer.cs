using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

    public Transform target;
    Vector3 offset;
	// Use this for initialization
	void Start () {



        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position = target.position + offset;
        }
	}
}

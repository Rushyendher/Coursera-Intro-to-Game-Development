using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 0.2f;
	public float gravity = 9.81f;

    private Transform playerTransform;
    private CharacterController playerController;
    private Vector3 playerMovement;

    // Use this for initialization
    void Start () {
        playerTransform = GetComponent<Transform>();
        playerController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        playerMovement = playerTransform.TransformDirection(playerMovement);
        playerMovement = playerMovement * movementSpeed;

		playerMovement.y -= gravity * Time.deltaTime;

        playerController.Move(playerMovement);
	}
}

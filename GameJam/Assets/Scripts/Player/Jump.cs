using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	[Header("Player")]
	public float jump_height;

	//jump variables
	private CharacterController characterController;

	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private bool jump = false;
	private float gravity = -9.81f;

	void Start()
    {
		characterController = GetComponent<CharacterController>();
	}

    void Update()
    {
		if (Input.GetKey(KeyCode.Space)) jump = true;

		JumpMovement();
	}

	private void FixedUpdate()
	{

	}

	private void JumpMovement()
	{
		groundedPlayer = characterController.isGrounded;

		if (groundedPlayer)
		{
			playerVelocity.y = 0;
		}

		if (jump && groundedPlayer)
		{
			playerVelocity.y += Mathf.Sqrt(jump_height * -1 * gravity);
			jump = false;
		}

		playerVelocity.y += gravity * Time.deltaTime;
		characterController.Move(playerVelocity * Time.deltaTime);
	}
}

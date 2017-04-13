using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingController : MonoBehaviour {

	// the character's speed
	float speed = 5f;

	// the character's jump force
	float jumpForce = 500f;

	// this is the character's physics component
	Rigidbody playerRB;


	// the ground checking object
	Transform groundCheck;

	// is the player touching the ground?
	bool isGrounded = true;

	// the player's default position
	Vector3 defaultPos;


	// when the script is activated, get its components
	void Awake () {

		groundCheck = transform.Find ("groundCheck");
		defaultPos = transform.position;

	}

	// since we're using physics, use the FixedUpdate method
	void FixedUpdate () {

		// this tackles the left and right arrow keys
		float h = Input.GetAxisRaw ("Horizontal");

		// jump to the Move method
		Move (h);

		// make the character jump!
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			playerRB.AddForce (Vector2.up * jumpForce);
		}

	}

	// when the player disappears, reset him
	void OnBecameInvisible () {

		transform.position = defaultPos;
		transform.rotation = Quaternion.identity;

	}


	// we can use this to move the character
	void Move (float h) {

		// refer to the current physics movement
		Vector3 movement = playerRB.velocity;
		movement.x = h * speed;

		// make the character move
		playerRB.velocity = movement;

		// if h is zero, character is still
		// if h is not zero, character is moving
		bool isWalking = (h != 0f);

		}

	}

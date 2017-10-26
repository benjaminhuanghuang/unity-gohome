using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody rb;
	private float maxSpeed = 10f;
	private Vector3 spawn;

	public float moveSpeed;
	public GameObject deathParticles;
	
	// Use this for initialization
	void Start () {
		spawn = transform.position;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate ()
	{
		
		if(rb.velocity.magnitude < maxSpeed)
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			// GetComponent<Rigidbody>().velocity = movement * moveSpeed; 
			rb.AddRelativeForce(movement * moveSpeed);  // based on player's rotation
		}

		if(transform.position.y < -2)
		{
			Die();
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "Enemy")
		{
			Die();
		}
	}

	void Die(){
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270, 0, 0));
		transform.position = spawn;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Goal")
		{
			GameManager.CompleteLevel();
		}
	}
}
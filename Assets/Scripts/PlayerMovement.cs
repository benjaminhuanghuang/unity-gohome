using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	private CharacterController characterController;
	public GameObject deathParticles;
	private Vector3 spawn;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		characterController.SimpleMove(moveDirection * moveSpeed);
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
}
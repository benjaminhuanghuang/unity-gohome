using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
	public Transform[] patrolPoints;
	private int currPoint;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		transform.position = patrolPoints[0].position;
		currPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position == patrolPoints[currPoint].position)
		{
			currPoint++;
			if(currPoint >= patrolPoints.Length)
				currPoint = 0;
		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currPoint].position, 
													moveSpeed * Time.deltaTime);
	}
}

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	
	public Rigidbody rbody; 
	public float moveSpeed = 10f; 
	
	
	void FixedUpdate () {
		
		rbody.velocity = transform.forward * moveSpeed + Physics.gravity;  
		
		Ray moveRay = new Ray (transform.position, transform.forward);
		
		if (Physics.Raycast (moveRay, 3f)) {
			int rand = Random.Range (0,3);
			if (rand == 0) {
				transform.Rotate (0f ,90f, 0f);
			} else {
				transform.Rotate (0f, -90f, 0f);
			}
		}
	}
}
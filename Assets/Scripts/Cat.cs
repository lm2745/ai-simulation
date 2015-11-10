using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
	
	public Transform Mouse;
	Movement moveScript;
	public Rigidbody rbodyCat; 
	public AudioSource NyanCat;
	
	bool pouncing = false;
	
	float cat_movespeed = 10.0f;
	
	void Start () {
		moveScript = GetComponent<Movement>();
	}
	
	void FixedUpdate () {

		for (int i=0; i<GameManager.listOfCats.Count; i++) {
			
			//declare a var of type Vector3, called "directionToMouse", set to a vector that goes from [current position] to [mouse's current position]
			Vector3 directionToMouse = GameManager.listOfCats[i].transform.position - transform.position;

		if (Mouse != null) {
			float angle = Vector3.Angle(transform.forward, directionToMouse);
			if ( angle < 90f) {
				Ray catRay = new Ray(transform.position, directionToMouse);
				RaycastHit catRayHitInfo = new RaycastHit();
				
				if (Physics.Raycast(catRay, out catRayHitInfo, 50f)) {
					Debug.DrawRay (catRay.origin, catRay.direction);
					
					if (catRayHitInfo.collider.tag == "Mouse") {
						if (catRayHitInfo.distance <= 5f) { 
							Destroy (Mouse.gameObject);
							Debug.Log ("pounced");
						} else { 
							rbodyCat.AddForce (directionToMouse.normalized * 1000f); 
							NyanCat.Play();
						}
					}
				}
			}
		}
	}
}
}
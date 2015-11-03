using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
	
	public Transform Mouse;
	Movement moveScript;
	public Rigidbody rbodyCat; 
	public AudioSource meow;
	public AudioSource win;
	
	bool pouncing = false;
	
	float cat_movespeed = 10.0f;

	void Start () {
		moveScript = GetComponent<Movement>();
	}

	void FixedUpdate () {

		if (Mouse != null) {
			Vector3 directionToMouse = Mouse.transform.position - transform.position;
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
									meow.Play();
								}
					}
	}
			}
		}
	}
}

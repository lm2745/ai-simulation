using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	
	public Transform cat;
	public Rigidbody rbodyMouse;
	public AudioSource squeak;
	
	void FixedUpdate () {
		
		Vector3 directionToCat = cat.transform.position - transform.position;
		float angle = Vector3.Angle (directionToCat, transform.forward);  
		
		if (angle < 180f) {
			Ray mouseRay = new Ray (transform.position, directionToCat);
			RaycastHit mouseRayHitInfo = new RaycastHit ();
			
			if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 100f)) {
				Debug.DrawRay (mouseRay.origin, mouseRay.direction);

			if (mouseRayHitInfo.collider.tag == "Cat") { 
					rbodyMouse.AddForce (-directionToCat.normalized * 1000f);
					squeak.Play();
				}
			}
		}
	}	
}
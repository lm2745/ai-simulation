using UnityEngine;
using System.Collections;

public class WallMaker : MonoBehaviour {
	
	public Transform wallmakerPrefab;
	public Transform wallPrefab;
	
	private int numChildren; 
	private int doors; 
	private float childCreate; 
	private bool createdDoor = false; 
	
	void Start(){
		numChildren = Random.Range(1,10);
		doors = numChildren + 1;
		childCreate = 0.80f;
	}

	void Update () {
		//	if (Input.GetKeyDown (KeyCode.Space)){
		transform.Translate (new Vector3(0, 0, wallPrefab.localScale.z));
		float rand = Random.Range(0.0f, 1.0f);
		if ( rand >= childCreate && (doors > 0 || numChildren > 0)){ 
			if(!createdDoor && doors > 0){ 
				transform.Translate(new Vector3 (0, 0, wallPrefab.localScale.z));
				doors--;
				Debug.Log ("Door Created. Door = " + doors);
				createdDoor = true;
			} else if(createdDoor && numChildren > 0){ 
				Quaternion rot = transform.rotation;
				rot.eulerAngles += new Vector3 (0.0f, numChildren % 2 * 180.0f + 90.0f, 0.0f);
				if ( rot.eulerAngles.y % 360 == 90.0f){
					Instantiate (wallmakerPrefab, transform.position -  new Vector3(wallPrefab.localScale.x, 0, wallPrefab.localScale.z), rot);
				} else { 
					Instantiate (wallmakerPrefab, transform.position -  new Vector3(-wallPrefab.localScale.x, 0, wallPrefab.localScale.z), rot);
				}
				numChildren--;
				Debug.Log ("Child Created. Children = " + numChildren);
				createdDoor = false;
			}
		} else { 
			Instantiate (wallPrefab, transform.position - new Vector3(0, 0, wallPrefab.localScale.z), transform.rotation);
		}
		//}
	}
	
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag != "wallmaker"){
			this.gameObject.SetActive(false);
			Destroy(this.gameObject);
		}
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public GameObject catPrefab;
	public GameObject mousePrefab;

	
	public static List<GameObject> listOfCats = new List<GameObject>();
	public static List<GameObject> listOfMice = new List<GameObject>();
	

	void Update () {
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit mouseRayHit = new RaycastHit();
		
	
		if (Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast (mouseRay, out mouseRayHit, 100f)) {
				GameObject newCat = (GameObject)Instantiate (catPrefab, mouseRayHit.point + new Vector3 (0f, 90f, 0f), Quaternion.identity);
				listOfCats.Add (newCat);
			}
		}
		

		if (Input.GetMouseButtonDown(1)) {
			if (Physics.Raycast (mouseRay, out mouseRayHit, 100f)) {
				GameObject newMouse = (GameObject)Instantiate (mousePrefab, mouseRayHit.point + new Vector3 (0f, -90f, 0f), Quaternion.identity);
				listOfMice.Add (newMouse);
			}
		}
	}
}
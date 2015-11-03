using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	
	public void ClickToRestart () {
		
		Application.LoadLevel (Application.loadedLevel) ;
	}
}
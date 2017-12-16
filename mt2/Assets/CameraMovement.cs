using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private Vector3 Opening;
	private Vector3 Contents;

	private float speed = 8f;

	// Use this for initialization
	void Start () {
		// Place for camera before and after opening
		Opening = new Vector3 (-1, 4, -17);
		Contents = new Vector3 (9, 4, -17);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator OpenCrateMovement(){
		Debug.Log (Vector3.Distance (transform.position, Opening));
		while (Vector3.Distance (transform.position, Contents) > 1) {
			transform.position = Vector3.MoveTowards (transform.position, Contents, speed * Time.deltaTime);
			yield return new WaitForSeconds (0.01f);
		}
		yield return null;
	}
}

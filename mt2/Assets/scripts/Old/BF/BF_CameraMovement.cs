using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BF_CameraMovement : MonoBehaviour {

	private Vector3 Opening;
	private Vector3 Contents;

	private BF_StateController stateController;

	private float speed = 8f;

	// Use this for initialization
	void Start () {
		// Place for camera before and after opening
		Opening = new Vector3 (-1, 4, -17);
		Contents = new Vector3 (11, 4, -17);

		// state control because coroutine is async
		stateController = GameObject.FindGameObjectWithTag ("StateController").GetComponent<BF_StateController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator OpenCrateMovement(){
		//Debug.Log ("move camera");
		// Stop for a few seconds at first for crate opening animation
		yield return new WaitForSeconds(0.7f);

		// Debug.Log (Vector3.Distance (transform.position, Opening));
		while (Vector3.Distance (transform.position, Contents) > 0.1f) {
			transform.position = Vector3.MoveTowards (transform.position, Contents, speed * Time.deltaTime);
			yield return new WaitForSeconds (0.01f);
		}
		// State should be 1 (for opening crates), placed after open animation
		stateController.changeState(1);

		yield return null;
	}

	public IEnumerator BackMovement(){
		//Debug.Log ("move camera back");
		//Debug.Log (Vector3.Distance (transform.position, Contents));
		while (Vector3.Distance (transform.position, Opening) > 0.1f) {
			transform.position = Vector3.MoveTowards (transform.position, Opening, speed * Time.deltaTime);
			yield return new WaitForSeconds (0.01f);
		}
		// State should be 1 (for opening crates), placed after open animation
		stateController.changeState(0);

		yield return null;
	}
}

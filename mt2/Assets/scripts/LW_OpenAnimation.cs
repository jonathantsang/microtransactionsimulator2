using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LW_OpenAnimation : MonoBehaviour {

	Animator animator;
	Vector3 Opening;
	Vector3 Contents;

	private float speed = 8f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		Opening = new Vector3 (0, 2, -10);
		Contents = new Vector3 (0, 2, -4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RotateCamera(){
		animator.SetTrigger ("LW_Open");
	}

	public void MoveCameraForwards(){
		StartCoroutine (OpenCrateMovement());
	}

	public void MoveCameraBackwards(){
		StartCoroutine (BackMovement ());
	}

	public IEnumerator OpenCrateMovement(){
		Debug.Log ("move camera");
		yield return new WaitForSeconds (0.8f);
		// Debug.Log (Vector3.Distance (transform.position, Opening));
		while (Vector3.Distance (transform.position, Contents) > 0.1f) {
			transform.position = Vector3.MoveTowards (transform.position, Contents, speed * Time.deltaTime);
			yield return new WaitForSeconds (0.01f);
		}

		yield return null;
	}

	public IEnumerator BackMovement(){
		Debug.Log ("move camera back");
		Debug.Log (Vector3.Distance (transform.position, Contents));
		while (Vector3.Distance (transform.position, Opening) > 0.1f) {
			transform.position = Vector3.MoveTowards (transform.position, Opening, speed * Time.deltaTime);
			yield return new WaitForSeconds (0.01f);
		}

		yield return null;
	}
}

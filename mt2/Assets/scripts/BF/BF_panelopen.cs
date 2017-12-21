using UnityEngine;
using System.Collections;

public class BF_panelopen : MonoBehaviour {
	Animation animation;
	Animator animator;

	void Start(){
		animation = GetComponent<Animation> ();
		animator = GetComponent<Animator> ();
	}

	public void open(){
		Debug.Log("PrintEvent: " + "open" + " called at: " + Time.time);
	}

	void Update(){
		
	}

	public void OpenAnimation(){
		Debug.Log ("opening");
		animator.SetTrigger ("opening");
	}
}
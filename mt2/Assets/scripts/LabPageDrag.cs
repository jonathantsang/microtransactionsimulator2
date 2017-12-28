using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LabPageDrag : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	GameObject obj;

	void OnMouseDown()
	{
		Debug.Log ("down");
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z-10);

		// Want to duplicate sprite for cursor
		if (obj == null) {
			Sprite spr = gameObject.GetComponent<Image> ().sprite;
			obj = new GameObject ();
			obj.AddComponent<SpriteRenderer> ();
			obj.GetComponent<SpriteRenderer> ().sprite = spr;
			obj.transform.position = Camera.main.ScreenToWorldPoint (curScreenPoint);
			Debug.Log (obj.transform.position);
		}
		// after done dragging
		// Destroy(obj);
	}
}

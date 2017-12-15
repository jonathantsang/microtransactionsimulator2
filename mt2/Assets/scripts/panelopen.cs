using UnityEngine;
using System.Collections;

public class panelopen : MonoBehaviour
{
	public Vector3 Pivot;
	public bool DebugInfo = true;

	//it could be a Vector3 but its more user friendly
	public bool RotateX = false;
	public bool RotateY = true;
	public bool RotateZ = false;
	public bool clockwise = true;
	private float counter = 0;
	private float amt = 2.2f;

	private int direction = 45;

	private Animation animation;

	void Start(){
		if (clockwise) {
			direction = 45;		
		} else {
			direction = -45;
		}
		animation = GetComponent<Animation> ();
		open ();
	}

	void FixedUpdate() {
	}

	public void open(){
		animation.Play ();
		animation.wrapMode = WrapMode.Once;
	}


	void open(){
		if (counter <= amt) {
			transform.position += (transform.rotation*Pivot);

			if (RotateX)
				transform.rotation *= Quaternion.AngleAxis(direction*Time.deltaTime, Vector3.right);
			if (RotateY)
				transform.rotation *= Quaternion.AngleAxis(direction*Time.deltaTime, Vector3.up);
			if (RotateZ)
				transform.rotation *= Quaternion.AngleAxis(direction*Time.deltaTime, Vector3.forward);

			transform.position -= (transform.rotation*Pivot);
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.004f);

			if (DebugInfo)
			{
				Debug.DrawRay(transform.position,transform.rotation*Vector3.up,Color.black);
				Debug.DrawRay(transform.position,transform.rotation*Vector3.right,Color.black);
				Debug.DrawRay(transform.position,transform.rotation*Vector3.forward,Color.black);  

				Debug.DrawRay(transform.position+(transform.rotation*Pivot),transform.rotation*Vector3.up,Color.green);
				Debug.DrawRay(transform.position+(transform.rotation*Pivot),transform.rotation*Vector3.right,Color.red);
				Debug.DrawRay(transform.position+(transform.rotation*Pivot),transform.rotation*Vector3.forward,Color.blue);
			}
		}
		counter += Time.deltaTime;
	}
}
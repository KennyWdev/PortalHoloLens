using UnityEngine;
using System.Collections;

public class Drop_On_Ground_Detected : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	//drop the cube when the ground has been mapped
	void FixedUpdate() 
	{
		Vector3 dir = transform.TransformDirection(Vector3.down);

		if (Physics.Raycast (transform.position, dir, 20)) {
			print ("Ground detected");
			GetComponent<Rigidbody> ().isKinematic = false;
			Destroy (this);
		}
	}
	// Update is called once per frame
	void Update () {

	}
}

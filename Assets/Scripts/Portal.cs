using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	//orange or blue portal
	public GameObject otherPortal; 

	//play the sound for going through a portal
	public GameObject goThroughSFX;

	private bool exists = false;
	// Use this for initialization
	void Start () {
		
	}

	public bool Check_Exists()
	{
		return exists;
	}

	public void Create()
	{
		exists = true;
		this.GetComponent<Animator> ().SetTrigger ("Create");
	}

	public void Portal_SFX()
	{
		this.GetComponent<AudioSource> ().Play ();
	}

	void OnTriggerEnter(Collider collider) {
		//check tag
		if (collider.tag == "Portal_Object") {
			//check if other portal exists
			if (otherPortal.transform.GetChild (0).GetComponent<Portal> ().Check_Exists ()) {
				collider.transform.position = (otherPortal.transform.position + otherPortal.transform.forward * 0.25f);
				float velocity_magnitude = Vector3.Magnitude(collider.GetComponent<Rigidbody> ().velocity);
				collider.GetComponent<Rigidbody> ().velocity = otherPortal.transform.forward * velocity_magnitude;
				goThroughSFX.GetComponent<AudioSource> ().Play ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

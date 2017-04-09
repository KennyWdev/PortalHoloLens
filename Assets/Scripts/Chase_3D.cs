using UnityEngine;
using System.Collections;

public class Chase_3D : MonoBehaviour {

	//chase speed
	public float smoothTime = 3.0f;

	public Transform target;
	public GameObject camera;

	private Vector3 velocity = Vector3.zero;

	public bool followPosition = true;
	public bool followOrientation = false;

	private Transform originalTarget;

	// Use this for initialization
	void Start () {
		originalTarget = target;
	}

	public void ResetTarget() {
		target = originalTarget;
	}
	// Update is called once per frame
	void Update () {
		
		if(followPosition) //follow the position of the target
			transform.position = Vector3.SmoothDamp (transform.position, target.transform.position, ref velocity, smoothTime);
		if(followOrientation) //follow the rotation of the target
			transform.LookAt (transform.position + camera.transform.rotation * Vector3.forward,	camera.transform.rotation * Vector3.up);
		else 
			transform.LookAt (transform.position + camera.transform.rotation * Vector3.forward, Vector3.up);
	}
}

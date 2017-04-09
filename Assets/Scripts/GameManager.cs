using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//singleton instance
	public static GameManager Instance;

	bool holdingItem = false;
	public GameObject selectionSFX;
	public GameObject portalGun;
	public GameObject cursor;
	public GameObject mainCamera;
	public GameObject cube;

	//stores current raytrace data of the position and rotation for the next portal to be shot
	private GameObject portalTarget;

	void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		portalTarget = new GameObject();

		//grab companion cube when the game starts
		PortalObjectSelect ();
	}

	//reset the scene
	public void OnReset() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	//pick up and drop the cube
	public void PortalObjectSelect() {
		
		if (!holdingItem) {
			cube.GetComponent<Chase_3D> ().enabled = true;
			cube.GetComponent<Rigidbody> ().useGravity = false;
			selectionSFX.GetComponent<AudioSource> ().Play ();
		} else {
			cube.GetComponent<Chase_3D> ().enabled = false;
			cube.GetComponent<Rigidbody> ().useGravity = true;
		}
		holdingItem = !holdingItem;
		portalGun.GetComponent<Portal_Gun> ().Set_Item_Picked_Up (holdingItem);
	}


	public void Calculate_Portal_Position() {
		Vector3 headPosition = mainCamera.transform.position;
		Vector3 gazeDirection = mainCamera.transform.forward;

		RaycastHit hitInfo;
		if (Physics.Raycast (headPosition, gazeDirection, out hitInfo)) {
			//when the raycast hits an object or wall, store the data
			portalTarget.transform.position = hitInfo.point;
			portalTarget.transform.tag = hitInfo.transform.gameObject.tag;
			portalTarget.transform.rotation = Quaternion.LookRotation (hitInfo.normal, mainCamera.transform.up);
		}
	}

	public void ShootPortalGun() {
		//shoot only when pointing at a wall
		if (portalTarget.tag == "Wall") {
			portalGun.GetComponent<Portal_Gun> ().Shoot (portalTarget.transform);
		}
	}

	// Update is called once per frame
	void Update () {
		Calculate_Portal_Position ();

		//shoot portal command for unity editor
		if (Input.GetKeyDown (KeyCode.Space))
			ShootPortalGun ();	
	}
}

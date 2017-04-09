using UnityEngine;
using System.Collections;

public class Portal_Gun : MonoBehaviour {

	public GameObject model;
	public GameObject[] staticVFX;
	public GameObject[] trailVFX;
	public GameObject modelTarget;

	public GameObject[] portals;
	public int portalSelection;

	public GameObject cursorMesh;

	// Use this for initialization
	void Start () {
	}

	//setting the new portal's position and orientation
	public void Set_Portal_At(Transform transform)
	{
		if (!portals [portalSelection].activeSelf)
			portals [portalSelection].SetActive (true);
		
		portals[portalSelection].transform.position = transform.position;
		portals[portalSelection].transform.rotation = transform.rotation;

		//script is attached to the child (model) object
		portals [portalSelection].transform.GetChild(0).GetComponent<Portal> ().Create (); 
		portalSelection++;

		//chaging the cursor's color to indicate the next portal (orange/blue) to be shot
		if (portalSelection > 1) {
			portalSelection = 0;
			cursorMesh.GetComponent<Renderer> ().material.color = new Color32 (255, 100, 0, 255);
		} 
		else {
			cursorMesh.GetComponent<Renderer> ().material.color = new Color32 (0, 100, 255, 255);
		}
	}

	//shoot animation
	public void Shoot(Transform transform) {
		model.GetComponent<Animator> ().SetTrigger ("Shoot");
		trailVFX[portalSelection].GetComponent<ParticleSystem> ().Stop ();
		trailVFX[portalSelection].GetComponent<ParticleSystem> ().Play ();
		trailVFX[portalSelection].GetComponent<AudioSource> ().Play ();
		Set_Portal_At(transform);
	}

	//item pickup animation
	public void Set_Item_Picked_Up(bool val) {
		staticVFX [0].SetActive (val);
		staticVFX [1].SetActive (val);

		if (val) {
			modelTarget.transform.localPosition = new Vector3 (0.015f, 0, 1.172f);

		} else {
			modelTarget.transform.localPosition = new Vector3 (0.015f, 0, 1.272f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

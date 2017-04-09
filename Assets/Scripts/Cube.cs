//using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace HoloToolkit.Unity.SpatialMapping
{
	public class Cube : MonoBehaviour, IInputClickHandler {

		//maximum fall distance for reseting the cube
		public float maxFallResetDistance = 40;

		// Use this for initialization
		void Start () {
			
		}

		void OnTriggerEnter(Collider collision) {
			//ignore collision between cube and wall if cube enters a portal
			if (collision.gameObject.tag == "Orange_Portal" || collision.gameObject.tag == "Blue_Portal") {
					Physics.IgnoreLayerCollision (8, 9, true);
			}
		}
		void OnTriggerExit(Collider collision) {
			//reset collision
			if (collision.gameObject.tag == "Orange_Portal" || collision.gameObject.tag == "Blue_Portal") {
					Physics.IgnoreLayerCollision (8, 9, false);
			}
		}


		// Update is called once per frame
		void Update () {

			//reset cube if it falls below the ground
			if (transform.position.y < -maxFallResetDistance) {
				transform.position = Camera.current.transform.position;
				gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GameManager.Instance.PortalObjectSelect ();
			}
		}

		public virtual void OnInputClicked(InputClickedEventData eventData) {
			GameManager.Instance.SendMessage ("PortalObjectSelect");
		}
	}
}
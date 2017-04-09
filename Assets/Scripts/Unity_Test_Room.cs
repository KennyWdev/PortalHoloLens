using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity_Test_Room : MonoBehaviour {

	private void Awake() {
#if !UNITY_EDITOR
		Destroy(this.gameObject);
#endif

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

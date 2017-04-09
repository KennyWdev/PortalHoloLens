using UnityEngine;
using System.Collections;

public class Destroy_Upon_Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		//destroy particle system when finished playing
	    if(!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
	}
}

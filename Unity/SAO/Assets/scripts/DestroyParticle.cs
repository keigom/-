using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {
	public float dest_time=5f;
	// Use this for initialization
	void Start () {
		Invoke ("dest", dest_time);
	}
	
	// Update is called once per frame

	void dest(){
		Destroy (gameObject);
	}
}
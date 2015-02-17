using UnityEngine;
using System.Collections;

public class scene02 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Jump")) {
			Application.LoadLevel("SAO with Goblin Oculus NR");
		}
	}
}

using UnityEngine;
using System.Collections;

public class FowardDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.tag == "Enemy"){
			col.gameObject.SendMessage("Damage");
		}
	}
}


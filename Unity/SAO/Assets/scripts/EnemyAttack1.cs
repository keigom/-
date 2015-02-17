using UnityEngine;
using System.Collections;

public class EnemyAttack1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage("BigDamage");
		}
	}
}


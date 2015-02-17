using UnityEngine;
using System.Collections;

public class tresurebox : MonoBehaviour {
	private Animator animator;
	private bool open;
	private bool key;
	public AudioClip OpenSound;
	public AudioClip SpawnSound;
	public GameObject enemy;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = OpenSound;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemyUnits.Length == 0) {
			//敵全滅時の処理
			if(col.gameObject.tag == "Player"){
				if(open == false){
					audioSource.Play ();
				}
				animator.SetBool ("open", true);
				open = true;
				Invoke("Spawn_anohito", 3);
			}
		}
	}

	void Spawn_anohito(){
		audioSource.clip = SpawnSound;
		audioSource.Play ();
		Vector3 pos = new Vector3 (0, 0.2f, -3);
		GameObject.Instantiate(enemy, pos, Quaternion.identity);
	}
}
using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharacterController))]

public class PlayerController3 : MonoBehaviour {
	private Animator animator;
	//private CharacterController controller;

	TGCConnectionController controller;

	//private int poorSignal0;
	private int poorSignal1;
	private int attention0=100;
	private int attention1=100;
	private int attention_dif;
	private int meditation0;
	private int meditation1;
	private int meditation_dif;
	
	void Start () {
		// Animatorコンポーネントを取得する
		animator = GetComponent<Animator> ();
//		controller = GetComponent<CharacterController> ();
		// CharactorControlコンポーネントのHeight、Centerの初期値を保存する
//		controller = GetComponent<CharacterController> ();

		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		//controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
	}

	void OnUpdateAttention(int value){
		attention0 = attention1;
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation0 = meditation1;
		meditation1 = value;
	}
	
	// Update is called once per frame
	void Update () {
				attention_dif = attention1 - attention0;
				meditation_dif = meditation1 - meditation0;
				//show move animation
				if (attention_dif >= 10 && attention_dif<20) {
						animator.SetBool ("Run", true);
				} else if (attention_dif <= -10) {
						animator.SetBool ("Run", false);
				}
				if (attention_dif >= 20) {
						animator.SetBool ("Avoid", true);
				} else {
						animator.SetBool ("Avoid", false);
				}
				if(meditation_dif <= -10) {
						animator.SetBool ("Attack", true);
				} else {
						animator.SetBool ("Attack", false);
				}
		}
}


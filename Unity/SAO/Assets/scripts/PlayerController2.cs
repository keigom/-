using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharacterController))]

public class PlayerController2 : MonoBehaviour {
	private Animator animator;
	//private CharacterController controller;

	TGCConnectionController controller;

	private int poorSignal1;
	private int attention1;
	private int meditation1;
	
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
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
	}
	
	// Update is called once per frame
	void Update () {

		//show move animation
		if (attention1>=50&&attention1<70) {
			animator.SetBool ("Run", true);
		} else {
			animator.SetBool ("Run", false);
		}
		if (attention1>=90) {
			animator.SetBool ("Avoid", true);
		} else {
			animator.SetBool ("Avoid", false);
		}
		if (attention1>=70&&attention1<90&&meditation1<70) {
			animator.SetBool ("Attack", true);
		} else {
			animator.SetBool ("Attack", false);
		}
	}
}

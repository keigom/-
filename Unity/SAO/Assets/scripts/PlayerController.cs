using UnityEngine;
using System.Collections;

//[RequireComponent(typeof (CharacterController))]

public class PlayerController : MonoBehaviour {
	private Animator animator;
	//private CharacterController controller;

	//TGCConnectionController controller;

	//private int poorSignal1;
	//private int attention1;
	//private int meditation1;
	// キャラクターコントローラ（カプセルコライダ）の移動量
	private Vector3 velocity;

	// 以下キャラクターコントローラ用パラメタ
	// 前進速度
	public float forwardSpeed = 7.0f;
	// 後退速度
	public float backwardSpeed = 2.0f;
	// 旋回速度
	public float rotateSpeed = 2.0f;
	
	void Start () {
		// Animatorコンポーネントを取得する
		animator = GetComponent<Animator> ();
//		controller = GetComponent<CharacterController> ();
		// CharactorControlコンポーネントのHeight、Centerの初期値を保存する
//		controller = GetComponent<CharacterController> ();

//		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		//controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
//		controller.UpdateAttentionEvent += OnUpdateAttention;
//		controller.UpdateMeditationEvent += OnUpdateMeditation;
//	}

//	void OnUpdateAttention(int value){
//		attention1 = value;
//	}
//	void OnUpdateMeditation(int value){
//		meditation1 = value;
//	}
//	void OnUpdateDelta(float value){
		//delta = value;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");				// 入力デバイスの水平軸をhで定義
		float v = Input.GetAxis("Vertical");				// 入力デバイスの垂直軸をvで定義

		// 以下、キャラクターの移動処理
		velocity = new Vector3(0, 0, v);		// 上下のキー入力からZ軸方向の移動量を取得

		if (v > 0.1) {
			velocity *= forwardSpeed;		// 移動速度を掛ける
		} else if (v < -0.1) {
			velocity *= backwardSpeed;	// 移動速度を掛ける
		}

		// キャラクターのローカル空間での方向に変換
		velocity = transform.TransformDirection(velocity);
		// 上下のキー入力でキャラクターを移動させる
		transform.localPosition += velocity * Time.fixedDeltaTime;
		// 左右のキー入力でキャラクタをY軸で旋回させる
		transform.Rotate(0, h * rotateSpeed, 0);	
		//show move animation
		if (Input.GetKey ("up")) {
			animator.SetBool ("Run", true);
		} else {
			animator.SetBool ("Run", false);
		}
		if (Input.GetButton ("Jump")) {
			animator.SetBool ("Avoid", true);
			transform.localPosition -= velocity * Time.fixedDeltaTime;
		} else {
			animator.SetBool ("Avoid", false);
		}
		if (Input.GetKey ("z")) {
			animator.SetBool ("Attack", true);
		} else {
			animator.SetBool ("Attack", false);
		}
	}
}

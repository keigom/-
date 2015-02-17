using UnityEngine;
using System.Collections;

//[RequireComponent(typeof (CharacterController))]

public class PlayerControllerOculus : MonoBehaviour {
	private Animator animator;
	
	// キャラクターコントローラ（カプセルコライダ）の移動量
//	private Vector3 velocity;
	// 旋回速度
//	public float rotateSpeed = 2.0f;

	public AudioClip SwordSound;
	public AudioClip RunSound;
	AudioSource audioSource;
	
	void Start () {
		// Animatorコンポーネントを取得する
		animator = GetComponent<Animator> ();
		audioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
				bool attack = false;
				//Reset Camera
				if (Input.GetKeyDown (KeyCode.Return))
						OVRManager.display.RecenterPose ();
				//  Get Oculus Rotation
				OVRPose pose = OVRManager.display.GetHeadPose ();
				Quaternion rotation = pose.orientation;
				rotation.x = 0;
				rotation.z = 0;
				transform.rotation = rotation;
				float v = Input.GetAxis ("Vertical");				// 入力デバイスの垂直軸をvで定義

				// キャラクターのローカル空間での方向に変換
//				velocity = transform.TransformDirection (velocity);

				if (Input.GetKey ("up")) {
						if(!audioSource.isPlaying) {
							audioSource.clip = RunSound;
							audioSource.Play();
							}
				if (Input.GetKeyUp ("up")) {
					audioSource.Stop();
				}
						animator.SetBool ("Run", true);
				} else {
						animator.SetBool ("Run", false);
				}
				if (Input.GetButton ("Jump")) {
						animator.SetBool ("Avoid", true);
//						transform.localPosition -= velocity * Time.fixedDeltaTime;
				} else {
						animator.SetBool ("Avoid", false);
				}
				if (Input.GetKey ("z")) {
						if (!audioSource.isPlaying) {
								audioSource.clip = SwordSound;
								audioSource.Play (12000);
						}
						attack = true;
						animator.SetBool ("Attack", attack);
				} else {
						attack = false;
						animator.SetBool ("Attack", attack);
				}
		}
}

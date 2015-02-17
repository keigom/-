using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharacterController))]

public class PlayerControllerOculusNR : MonoBehaviour {
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
	public AudioClip SwordSound;
	public AudioClip RunSound;
	AudioSource audioSource;
	
	void Start () {
		// Animatorコンポーネントを取得する
		animator = GetComponent<Animator> ();
	
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		audioSource = gameObject.GetComponent<AudioSource> ();
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
		//Reset Camera
		if (Input.GetKeyDown (KeyCode.Return))
			OVRManager.display.RecenterPose();
		//  Get Oculus Rotation
		OVRPose pose = OVRManager.display.GetHeadPose();
		Quaternion rotation = pose.orientation;
		rotation.x = 0;
		rotation.z = 0;
		//Set rotation
		transform.rotation = rotation;


		attention_dif = attention1 - attention0;
		meditation_dif = meditation1 - meditation0;
		//show move animation
		if (attention_dif >= 10 && attention_dif<20) {
			if(!audioSource.isPlaying) {
				audioSource.clip = RunSound;
				audioSource.Play();
			}
			animator.SetBool ("Run", true);
		} else if (attention_dif <= -10) {
			animator.SetBool ("Run", false);
		}
		if(meditation_dif <= -10){
			if (!audioSource.isPlaying) {
				audioSource.clip = SwordSound;
				audioSource.Play (12000);
			}
			animator.SetBool ("Attack", true);
		} else {
			animator.SetBool ("Attack", false);
		}
		if (attention_dif >= 20) {
			animator.SetBool ("Avoid", true);
		} else {
			animator.SetBool ("Avoid", false);
		}
	}
}



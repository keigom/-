using UnityEngine;
using System.Collections;

public class DisplayGameOver : VRGUI
{	
	TGCConnectionController controller;
	
	private int poorSignal1;
	private int attention1;
	private int meditation1;

	private GUIStyle style;
	private bool music;
	public GUIStyleState styleState;

	public AudioClip FailSound;
	AudioSource audioSource;

	void Start()
	{
		style = new GUIStyle();
		style.fontSize = 200;
		style.fontStyle = FontStyle.Bold;

		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip =  FailSound;


		
	}
		
	public override void OnVRGUI()
	{
				GUILayout.BeginHorizontal ();
				GUI.backgroundColor = Color.red;
				style.normal = styleState;
				GUI.Label (new Rect (200, 200, 600, 600), ("Game Over"), style);
		if (music == false) {
						audioSource.Play (88200);
			music = true;		
		}

		GUILayout.EndHorizontal();
		
	}
}

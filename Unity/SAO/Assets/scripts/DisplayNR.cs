using UnityEngine;
using System.Collections;

public class DisplayNR : MonoBehaviour
{
	TGCConnectionController controller;
	
	private int poorSignal1;
	private int attention1;
	private int meditation1;

	private float hitPoints;
	
	void Start()
	{
		
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		
	}

	void OnUpdateAttention(int value){
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
	}
	
	public void OnVRGUI()
	{
		GUILayout.BeginHorizontal();
	
		GUI.backgroundColor = Color.red;
		GUI.HorizontalScrollbar(new Rect (0, 40,400,40), 0, attention1, 0, 100);
		GUI.backgroundColor = Color.blue;
		GUI.HorizontalScrollbar(new Rect (0,80,400,40), 0, meditation1, 0, 100);
		if(GameObject.Find("Asuna_ver1.0.1")){
			hitPoints = GameObject.Find("Asuna_ver1.0.1").GetComponent<AsunaDamageReceiver>().Health;
		GUI.backgroundColor = Color.green;
		GUI.HorizontalScrollbar(new Rect (0,0,400,40), 0, hitPoints, 0, 100);
		}
		else{
			GUI.backgroundColor = Color.green;
			GUI.HorizontalScrollbar(new Rect (0,0,400,40), 0, 0, 0, 100);
			Invoke("ChangeScene",3);
		}
		GUILayout.Space(Screen.width-250);
		
		GUILayout.EndHorizontal();

		
	}

	void ChangeScene(){
		Application.LoadLevel ("GameOver");
	}
}

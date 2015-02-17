using UnityEngine;
using System.Collections;

public class DisplayNROculus : VRGUI
{
	//public Texture2D[] signalIcons;
	
//	private int indexSignalIcons = 1;
	
	TGCConnectionController controller;
	
	private int poorSignal1;
	private int attention1;
	private int meditation1;

	private GUIStyle style;
	public GUIStyleState styleState;

	void Start()
	{
		
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		
		//controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		style = new GUIStyle();
		style.fontSize = 200;
		style.fontStyle = FontStyle.Bold;

		
	}
	
	/*void OnUpdatePoorSignal(int value){
		poorSignal1 = value;
		if(value < 25){
			indexSignalIcons = 0;
		}else if(value >= 25 && value < 51){
			indexSignalIcons = 4;
		}else if(value >= 51 && value < 78){
			indexSignalIcons = 3;
		}else if(value >= 78 && value < 107){
			indexSignalIcons = 2;
		}else if(value >= 107){
			indexSignalIcons = 1;
		}
	}*/

	void OnUpdateAttention(int value){
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
	}
	
	public override void OnVRGUI()
	{
		GUILayout.BeginHorizontal();
		
		
		/*if (GUILayout.Button("Connect"))
		{
			controller.Connect();
		}
		if (GUILayout.Button("DisConnect"))
		{
			controller.Disconnect();
			indexSignalIcons = 1;
		}*/

		GUI.backgroundColor = Color.red;
		//GUILayout.Label ("Atention");
		GUI.HorizontalScrollbar(new Rect (0,40,400,40), 0, attention1, 0, 100);
		GUILayout.Space (Screen.height - 400);
		GUI.backgroundColor = Color.blue;
		//GUILayout.Label ("Meditation");
		GUI.HorizontalScrollbar(new Rect (0,80,400,40), 0, meditation1, 0, 100);
		//hitpoint
		GUI.backgroundColor = Color.green;
		if (GameObject.Find ("Asuna_ver1.0.1")) {
						float hitPoints = GameObject.Find ("Asuna_ver1.0.1").GetComponent<AsunaDamageReceiver> ().Health;
						GUI.HorizontalScrollbar(new Rect (0,0,400,40), 0, hitPoints, 0, 100);		
				} else {
						float hitPoints = 0;
						GUI.HorizontalScrollbar(new Rect (0,0,400,40), 0, hitPoints, 0, 100);
						Invoke("ChangeScene", 1);
				}


		
		GUILayout.Space(Screen.width-250);
		//GUILayout.Label(signalIcons[indexSignalIcons]);
		
		GUILayout.EndHorizontal();
		
		//GUILayout.Label("PoorSignal1:" + poorSignal1);
		//GUILayout.Label("Delta:" + delta);
		
	}

	void ChangeScene(){
		Application.LoadLevel ("GameOver");
	}
}

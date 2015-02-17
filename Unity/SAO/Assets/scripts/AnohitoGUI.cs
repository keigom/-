using UnityEngine;
using System.Collections;

public class AnohitoGUI : VRGUI {

	private GUIStyle style;
	float hitPoints = 50f;
	public string name;

	void Start(){
				style = new GUIStyle ();
		style.fontSize = 32;
		style.fontStyle = FontStyle.Bold;
		}

		public override void OnVRGUI()
		{
			hitPoints = GetComponent<DamageReceiver>().Health;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			GUI.backgroundColor = Color.green;
			GUI.HorizontalScrollbar(new Rect (0,0,200,20), 0, hitPoints, 0, 10);
			GUI.Label (new Rect (0, 0, 600, 600), name, style);
			GUILayout.EndArea();
		}
	}
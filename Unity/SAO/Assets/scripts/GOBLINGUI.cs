using UnityEngine;
using System.Collections;

public class GOBLINGUI : VRGUI {

	float hitPoints = 50f;

		public override void OnVRGUI()
		{
			hitPoints = GetComponent<DamageReceiver>().Health;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			GUI.backgroundColor = Color.green;
			GUI.HorizontalScrollbar(new Rect (0,0,200,20), 0, hitPoints, 0, 10);
			GUILayout.EndArea();
		}
	}
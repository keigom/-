using UnityEngine;
using System.Collections;

public class RotationCamera : MonoBehaviour
{
	public Transform target;	// オブジェクト
	public float radius = 15.0f;	// オブジェクトからカメラまでの距離(円運動の半径)
	public float angle = 0.0f;	// ラジアン値
	public float damping = 5.0f;
	public void Start()
	{
//		target = GameObject.Find("Floor"); // オブジェクトをセット
	}
	
	public void Update()
	{
		Vector3 pos = target.position;
		transform.LookAt(pos);	// カメラをtargetの方向へ向かせるように設定する
		
		// オブジェクトの周りをカメラが円運動する
		transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x + Mathf.Cos(angle) * radius, pos.y, pos.z + Mathf.Sin(angle) * radius), damping*Time.deltaTime);
		angle += 0.01f;
	}
}
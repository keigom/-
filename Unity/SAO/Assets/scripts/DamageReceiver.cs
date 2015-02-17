using UnityEngine;
using System.Collections;

public class DamageReceiver : MonoBehaviour {
	public GameObject death_effect;
	private GameObject instantiatedObj;
	public float Health=10f;
	public float damage=2f;
	public float dest_time=5f;

	public AudioClip HurtSound;
	AudioSource audioSource;
	
	void Start()
	{
				audioSource = gameObject.GetComponent<AudioSource> ();
				audioSource.clip =  HurtSound;
		}
		
	void Damage()
	{
		audioSource.Play();
		Health -= damage;
		if(Health <= 0) 
		{
			Destroy (gameObject);
			instantiatedObj = (GameObject)Instantiate (death_effect, transform.position, Quaternion.identity);
		}
	}
	
}

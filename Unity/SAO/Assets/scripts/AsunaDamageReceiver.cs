using UnityEngine;
using System.Collections;

public class AsunaDamageReceiver : MonoBehaviour {
	public GameObject death_effect;
	private GameObject instantiatedObj;
	public float Health=100f;
	public float damage=1f;
	public float dest_time=5f;

	public AudioClip HurtSound;
	AudioSource audioSource;

	public float flashSpeed = 5f; 
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);  

	void Start()
	{
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip =  HurtSound;
	}

	void Damage()
	{
		//audioSource.Play();
		Health -= damage;
		if(Health <= 0) 
		{
			Destroy (gameObject);
			instantiatedObj = (GameObject)Instantiate (death_effect, transform.position, Quaternion.identity);
		}
	}

	void BigDamage()
	{
		//audioSource.Play();
		Health -= damage*5;
		if(Health <= 0) 
		{
			Destroy (gameObject);
			instantiatedObj = (GameObject)Instantiate (death_effect, transform.position, Quaternion.identity);
		}
	}
		
}

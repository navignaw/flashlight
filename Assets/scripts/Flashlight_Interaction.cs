using UnityEngine;
using System.Collections;

public class Flashlight_Interaction : MonoBehaviour {
	public GUIStyle aimStyle;
	public AudioClip onSound, offSound;
	private Light _light;
	
	void Awake() {
		if( GetComponent<AudioSource>() == null )
			gameObject.AddComponent<AudioSource>();
		_light = GetComponent<Light>();
		_light.enabled = false;
	}

	void Update() {
		if(Input.GetMouseButtonUp(0) )
		{
			_light.enabled = false;
			StopCoroutine( "FlashlightCast" );
			audio.clip = offSound;
			audio.Play();
		}
		
		if(Input.GetMouseButtonDown(0) )
		{
			_light.enabled = true;
			StartCoroutine( "FlashlightCast" );
			audio.clip = onSound;
			audio.Play();
		}
	}

	IEnumerator FlashlightCast()
	{
		while( true )
		{
			RaycastHit hit;
			Physics.Raycast( transform.position, transform.forward, out hit );
			if(hit.collider != null)
			{
				hit.collider.SendMessage( "Activate", SendMessageOptions.DontRequireReceiver );
			}

			yield return new WaitForFixedUpdate();
		}
	}
}

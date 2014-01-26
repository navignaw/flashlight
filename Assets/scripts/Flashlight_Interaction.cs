using UnityEngine;
using System.Collections;

public class Flashlight_Interaction : MonoBehaviour {
	public GUIStyle aimStyle;
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
		}
		
		if(Input.GetMouseButtonDown(0) )
		{
			_light.enabled = true;
			StartCoroutine( "FlashlightCast" );
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

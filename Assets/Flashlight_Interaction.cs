using UnityEngine;
using System.Collections;

public class Flashlight_Interaction : MonoBehaviour {
	public bool lightOnAtStart;
	public GUIStyle aimStyle;
	private Light _light;

	void Awake() {
		_light = GetComponent<Light>();
		_light.enabled = lightOnAtStart;
	}

	void Update() {
		if( Input.GetMouseButtonUp(0) ) {
			_light.enabled = !_light.enabled;
			if( _light.enabled )
				StartCoroutine( FlashlightCast() );
		}
	}

	IEnumerator FlashlightCast()
	{
		while( _light.enabled )
		{
			RaycastHit hit;
			Physics.Raycast( Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f)), out hit );
			if(hit.collider != null)
			{
				hit.collider.SendMessage( "Activate", SendMessageOptions.DontRequireReceiver );
			}

			yield return new WaitForFixedUpdate();
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width/2, Screen.height/2, 3, 3), "+", aimStyle);
	}
}

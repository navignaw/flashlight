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
			RaycastHit hit1, hit2, hit3, hit4, hit5;
			Vector3 v2 = Quaternion.AngleAxis(5, Vector3.up) * transform.forward;
			Vector3 v3 = Quaternion.AngleAxis(5, Vector3.down) * transform.forward;
			Vector3 v4 = Quaternion.AngleAxis(5, Vector3.left) * transform.forward;
			Vector3 v5 = Quaternion.AngleAxis(5, Vector3.right) * transform.forward;

			Physics.Raycast( transform.position, transform.forward, out hit1 );
			Physics.Raycast( transform.position, v2, out hit2 );
			Physics.Raycast( transform.position, v3, out hit3 );
			Physics.Raycast( transform.position, v4, out hit4 );
			Physics.Raycast( transform.position, v5, out hit5 );

			foreach (RaycastHit hit in new RaycastHit[] {hit1, hit2, hit3, hit4, hit5})
			{
				if (hit.collider != null)
					hit.collider.SendMessage( "Activate", SendMessageOptions.DontRequireReceiver );
			}

			yield return new WaitForFixedUpdate();
		}
	}
}

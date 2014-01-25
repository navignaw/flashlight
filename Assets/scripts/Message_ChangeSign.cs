using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Message_ChangeSign : MonoBehaviour {
	public Texture originalTexture, newTexture;
	public bool changeBack;
	public float changeBackTimer = 0.1f;

	private Coroutine coRoutine;
	
	void Awake()
	{
		renderer.material.mainTexture = originalTexture;
	}
	
	public void Activate()
	{
		renderer.material.mainTexture = newTexture;
		if( coRoutine != null )
			StopCoroutine( "resetText" );
		coRoutine = StartCoroutine( "resetText" );
	}
	
	IEnumerator resetText()
	{
		yield return new WaitForSeconds(changeBackTimer);
		renderer.material.mainTexture = originalTexture;
	}
}

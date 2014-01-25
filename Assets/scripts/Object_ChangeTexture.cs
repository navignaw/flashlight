using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Object_ChangeTexture : MonoBehaviour {
	public Texture originalTexture, newTexture;
	public bool changeBack;
	public float changeBackTimer = 0.1f;

	private Coroutine coRoutine;
	
	void Awake()
	{
		Debug.Log("Awakening");
		renderer.material.mainTexture = originalTexture;
		renderer.material.color = Color.white;
		renderer.material.shader = Shader.Find("Transparent/Diffuse");
	}
	
	public void Activate()
	{
		Debug.Log("Activating");
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

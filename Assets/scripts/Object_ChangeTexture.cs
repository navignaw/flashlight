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
		if (originalTexture != null)
			renderer.material.mainTexture = originalTexture;
	}
	
	public void Activate()
	{
		if (newTexture != null)
			renderer.material.mainTexture = newTexture;

		if (coRoutine != null)
			StopCoroutine("resetTexture");
		coRoutine = StartCoroutine("resetTexture");
	}
	
	IEnumerator resetTexture()
	{
		yield return new WaitForSeconds(changeBackTimer);
		if (originalTexture != null)
			renderer.material.mainTexture = originalTexture;
	}
}

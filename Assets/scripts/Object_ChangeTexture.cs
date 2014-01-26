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
		else
		{
			renderer.material.mainTexture = newTexture;
			renderer.enabled = false;
		}
	}
	
	public void Activate()
	{
		if (newTexture != null)
		{
			if (originalTexture == null)
				renderer.enabled = true;
			renderer.material.mainTexture = newTexture;
		}
		else
			renderer.enabled = false;

		if (coRoutine != null)
			StopCoroutine("resetTexture");
		coRoutine = StartCoroutine("resetTexture");
	}
	
	IEnumerator resetTexture()
	{
		yield return new WaitForSeconds(changeBackTimer);
		if (!renderer.enabled)
			renderer.enabled = true;
		else
		{
			if (originalTexture != null)
				renderer.material.mainTexture = originalTexture;
			else
				renderer.enabled = false;
		}
	}
}

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
		renderer.material.mainTexture = originalTexture;
		renderer.material.color = Color.white;
		renderer.material.shader = Shader.Find("Transparent/Diffuse");
	}
	
	public void Activate()
	{
		if (newTexture == null)
			renderer.enabled = false;
		else
			renderer.material.mainTexture = newTexture;

		if (coRoutine != null)
			StopCoroutine("resetText");
		coRoutine = StartCoroutine("resetText");
	}
	
	IEnumerator resetText()
	{
		yield return new WaitForSeconds(changeBackTimer);
		if (!renderer.enabled)
			renderer.enabled = true;
		else
			renderer.material.mainTexture = originalTexture;
	}
}

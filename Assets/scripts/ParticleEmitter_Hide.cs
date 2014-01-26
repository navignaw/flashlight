using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// TODO: fix particle system

public class ParticleEmitter_Hide : MonoBehaviour {
	public bool changeBack;
	public float changeBackTimer = 0.1f;

	private Coroutine coRoutine;
	
	void Awake()
	{
		//particleEmitter.emit = true;
	}
	
	public void Activate()
	{
		/*particleEmitter.emit = false;
		Debug.Log("particle cancelled");

		if (coRoutine != null)
			StopCoroutine("resetText");
		coRoutine = StartCoroutine("resetText");*/
	}
	
	IEnumerator resetText()
	{
		yield return new WaitForSeconds(changeBackTimer);
		particleEmitter.emit = true;
	}
}

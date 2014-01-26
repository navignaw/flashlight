using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// TODO: fix particle system

public class ParticleEmitter_Hide : MonoBehaviour {
	public bool changeBack;
	public float changeBackTimer = 0.1f;

	private Coroutine coRoutine;
	//private ParticleSystem particleSystem;
	
	void Awake()
	{
		//particleSystem = (ParticleSystem) gameObject.GetComponent("ParticleSystem");
		if (particleSystem != null)
			particleSystem.Play();//enableEmission = true;
	}
	
	public void Activate()
	{
		particleSystem.Stop();//.enableEmission = false;

		if (coRoutine != null)
			StopCoroutine("resetText");
		coRoutine = StartCoroutine("resetText");
	}
	
	IEnumerator resetText()
	{
		yield return new WaitForSeconds(changeBackTimer);
		particleSystem.Play();//.enableEmission = true;
	}
}

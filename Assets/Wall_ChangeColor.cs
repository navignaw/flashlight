using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wall_ChangeColor : MonoBehaviour {
	public Color changeColor;
	public bool changeBack;
	public float changeBackTimer = 0.1f;

	private Color originalColor;
	private Coroutine coRoutine;

	void Awake()
	{
		originalColor = GetComponent<Renderer>().material.color;
	}

	public void Activate()
	{
		GetComponent<Renderer>().material.color = changeColor;
		if( coRoutine != null )
			StopCoroutine( "resetColor" );
		coRoutine = StartCoroutine( "resetColor" );
	}

	IEnumerator resetColor()
	{
		yield return new WaitForSeconds(changeBackTimer);
		GetComponent<Renderer>().material.color = originalColor;
	}
}

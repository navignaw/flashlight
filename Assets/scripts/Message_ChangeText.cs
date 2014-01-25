using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Message_ChangeText : MonoBehaviour {
	public string originalText, changeText;
	public bool changeBack;
	public float changeBackTimer = 0.1f;

	private TextMesh textMesh;
	private Coroutine coRoutine;
	
	void Awake()
	{
		textMesh = GetComponent<TextMesh>();
		textMesh.text = originalText;
	}
	
	public void Activate()
	{
		textMesh.text = changeText;
		if( coRoutine != null )
			StopCoroutine( "resetText" );
		coRoutine = StartCoroutine( "resetText" );
	}
	
	IEnumerator resetText()
	{
		yield return new WaitForSeconds(changeBackTimer);
		textMesh.text = originalText;
	}
}

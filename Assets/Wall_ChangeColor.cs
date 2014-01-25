using UnityEngine;
using System.Collections;

public class Wall_ChangeColor : MonoBehaviour {
	public Color changeColor;

	public void Activate()
	{
		GetComponent<Renderer>().material.color = changeColor;
	}
}

using UnityEngine;
using System.Collections;

public class Seethrough : MonoBehaviour {

	GameObject glass;

	// Use this for initialization
	void Start () {
		glass.renderer.material.color.a = 0.5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

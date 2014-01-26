using UnityEngine;
using System.Collections;

public class lightflicker : MonoBehaviour {

	public float timeOn;
	public float timeOff;
	private float changeTime;
	
	void Update() {
		if (Time.time > changeTime) {
			light.enabled = !light.enabled;
			if (light.enabled) {
				changeTime = Time.time + Random.Range(0f,timeOn);
			} else {
				changeTime = Time.time + Random.Range(0f,timeOff);
			}
		}
	}
}
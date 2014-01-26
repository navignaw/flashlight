using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject cube;
	public GameObject handleSound;
	public GameObject doorSound;
	public Transform destination;

	public void OnTriggerEnter	(Collider other) {
		Debug.Log ("Init TPORT: " + other.transform.position);
		Debug.Log ("Init PLAY: " + destination.position);
		other.transform.position = destination.position;
		Debug.Log ("End TPORT: " + other.transform.position);
		Debug.Log ("Init PLAY: " + destination.position);
			handleSound.audio.Play ();
			doorSound.audio.Play ();
		}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

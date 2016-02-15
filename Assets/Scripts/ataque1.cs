using UnityEngine;
using System.Collections;

public class ataque1 : MonoBehaviour {

	public float 	delay;		// Duração do ataque
	private float 	tempo;		// Contador

	// Use this for initialization
	void Start () {

		tempo = delay;	
	}
	
	// Update is called once per frame
	void Update () {
	
		tempo -= Time.deltaTime;

		if (tempo < 0) {
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	private bool visible;
	private float tempo;
	private float tempoMax;
	public Renderer color;

	// Use this for initialization
	void Start () {

		visible = true;
		tempoMax = 5f;
		tempo = tempoMax;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (visible) {
			tempo -= 3 * Time.deltaTime;
		} else {
			tempo += 3 * Time.deltaTime;
		}

		if (tempo >tempoMax)
			visible = true;
		if (tempo < 0)
			visible = false;

		color.material.color = new Color (1f,1f,1f,(tempo/tempoMax));

		if ( Input.GetKeyDown (KeyCode.Space)) {

			Application.LoadLevel(1);
		}
	
	}
}

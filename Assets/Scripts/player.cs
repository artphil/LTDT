using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	//Movimento
	public  float       velocity;
	public	int			lado;

	// Animacao
	public  Transform   character;          //Personagem jogavel
	private Animator    anime;              //Animacao do personagem

	// Use this for initialization
	void Start () 
	{
		//Recupera a animacao do personagem
		anime = character.GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		// Controla movimento
		Move ();
	}
	
	// Controla movimento 
	void Move () {

		// Verifica a seta é solta
		if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) 
			|| Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			lado = 0;
		}

		// Verifica se seta direita e pressionada
		if (lado == 0 && Input.GetKeyDown(KeyCode.UpArrow)){
			lado = 1;
			anime.SetInteger ("lado", lado);			
		}
		// Verifica se seta baixo e pressionada
		if (lado == 0 && Input.GetKeyDown(KeyCode.DownArrow)){
			lado = 2;
			anime.SetInteger ("lado", lado);
		}
		// Verifica se seta esquerda e pressionada
		if (lado == 0 && Input.GetKeyDown(KeyCode.LeftArrow)){
			lado = 3;
			anime.SetInteger ("lado", lado);
			transform.eulerAngles = new Vector2 (0, 0);
		}
		// Verifica se seta direita e pressionada
		if (lado == 0 && Input.GetKeyDown(KeyCode.RightArrow)){
				lado = 4;
				anime.SetInteger ("lado", lado);
				transform.eulerAngles = new Vector2 (0, 180);
		}

		// Move o personagem
		if (lado == 1) {
			transform.Translate (Vector2.up * velocity * Time.deltaTime);
		} else if (lado == 2) {
			transform.Translate (Vector2.up * -velocity * Time.deltaTime);
		} else if (lado >= 3) {
			transform.Translate (Vector2.right * -velocity * Time.deltaTime);
		}
	}
	
	void OnCollisionEnter2D (Collision2D colisor) {
	
	}
	
}

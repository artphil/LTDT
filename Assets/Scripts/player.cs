using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	//Movimento
	public  float       velocity;
	public	int			lado;

	// Animacao
	public  Transform   character;          //Personagem jogavel
	private Animator    anime;              //Animacao do personagem

	// Vidas
	public int vidaMax;
	public int vidas;

	// Ataque
	public  GameObject  dano;            // Obj hit point
	private Vector2     danoposition;    // Posição do ataque

	// Use this for initialization
	void Start () 
	{
		// Inicializa vida
		vidas = vidaMax;
		// Recupera a animacao do personagem
		anime = character.GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		// Controla movimento
		Move ();

		// Controla o Ataque
		Ataca ();
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

	void Ataca () {

		// Determina a posicão do ataque
		danoposition = transform.position;

		if (lado == 1) {
			danoposition.y += 0.15f;
		} else if (lado == 2) {
			danoposition.y -= 0.15f;
		} else if (lado == 3) {
			danoposition.x -= 0.15f;
		} else if (lado == 4) {
			danoposition.x += 0.15f;
		}
			
		if (Input.GetKeyDown(KeyCode.Space)) {
			anime.SetTrigger ("ataque");
			Instantiate(dano, danoposition, transform.rotation);
		}
	}
	
	void OnCollisionEnter2D (Collision2D colisor) {
	
		if (colisor.gameObject.tag == "Enimie") {
			// Perda de vida
			vidas--;
		}

		if (vidas == 0){
			// Destroi personagem
			Destroy(gameObject);

		}
	}
	
}

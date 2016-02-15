using UnityEngine;
using System.Collections;

public class enimie : MonoBehaviour
{

    // Movimento
    public float velocity;              // Velocidade do inimigo
    public bool forRigth = true;        // Indica se direção é a direita
    public float runDelay;              // Tempo que caminha prara cada direção
    private float runningTime;          // Tempo de caminhada
    private bool running;               // Indica se está andando
	private int lado;					// Indica a direção a ser percorrida

    //Animação
    public Transform character;          //Personagem jogavel
    private Animator anime;              //Animação do personagem

	public int life;

    // Use this for initialization
    void Start()
    {
        // Carrega a animação
//        anime = character.GetComponent<Animator>();
        runningTime = 0;
        running = false;
		life = 10;

    }

    // Update is called once per frame
    void Update()
    {
		if (!running) {
			runDelay = Random.Range (1, 6);
			lado = Random.Range (0, 5);
			running = true;
		}

		Move ();

		runningTime += Time.deltaTime;
       

		if (life <= 0) {

			Destroy (gameObject);
		}

    }

	void Move ( ) {
		
		if (runningTime > runDelay)
		{
			runningTime = 0;
			running = false;
		}

		if (running)  {
			if (lado == 1) {
				transform.Translate (Vector2.up * velocity * Time.deltaTime);
			} else if (lado == 2) {
				transform.Translate (Vector2.up * -velocity * Time.deltaTime);
			} else if (lado == 3) {
				transform.eulerAngles = new Vector2(0, 180);
				transform.Translate (Vector2.right * -velocity * Time.deltaTime);
			} else if (lado == 4) {
				transform.eulerAngles = new Vector2(0, 0);
				transform.Translate (Vector2.right * -velocity * Time.deltaTime);
			}
		}			
	}

	void OnCollisionEnter2D (Collision2D colisor) {
		
		if (colisor.gameObject.tag == "p_ataque") {
			
			life -= 1;
		} else if (colisor.gameObject.tag == "Power2") {
			
			life -= 5;
		} else if (colisor.gameObject.tag == "Background") {

			lado -= 1;
			if (lado < 1)
				lado = 4;
		}
	}
}

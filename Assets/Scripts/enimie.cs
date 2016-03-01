using UnityEngine;
using System.Collections;

public class enimie : MonoBehaviour
{

    // Movimento
    public float velocity;              // Velocidade do padrão inimigo
	public float realVelocity;          // Velocidade do real inimigo
    public bool forRigth = true;        // Indica se direção é a direita
    public float runDelay;              // Tempo que caminha prara cada direção
    private float runningTime;          // Tempo de caminhada
    private bool running;               // Indica se está andando
	private bool vunerable;				// Indica que pode ser atacado
	private bool seePlayer;             // Indica viu o jogador
	private Vector2	rangeVision;		// Alcance da visao do mosntro
	private int lado;					// Indica a direção a ser percorrida

    //Animação
    public Transform character;          //Personagem jogavel
    private Animator anime;              //Animação do personagem
	private SpriteRenderer color;
	public int life;

    // Use this for initialization
    void Start()
    {
        // Carrega a animação
        anime = character.GetComponent<Animator>();
		color = character.GetComponent<SpriteRenderer>();
        runningTime = 0;
        running = false;
		life = 10;
		realVelocity = velocity;

    }

    // Update is called once per frame
    void Update()
    {
		if (!running && !seePlayer) {
			runDelay = Random.Range (1, 6);
			lado = Random.Range (1,4);
			running = true;
		}

		if (lado == 1) {
			rangeVision = transform.position;
			rangeVision.y += 5f;
		} else if (lado == 2) {
			rangeVision = transform.position;
			rangeVision.y -= 5f;
		} else if (lado == 3) {
			rangeVision = transform.position;
			rangeVision.x += 5f;
		} else if (lado == 4) {
			rangeVision = transform.position;
			rangeVision.x -= 5f;
		}

		seePlayer = Physics2D.Linecast (transform.position, rangeVision, 1 << LayerMask.NameToLayer("Player"));

		if (seePlayer) {
			
			realVelocity = 3 * velocity;
			vunerable = true;
			color.color = new Color(1f,1f,1f,1f);

		} else {
			
			realVelocity = velocity;
			vunerable = false;
			color.color = new Color(1f,1f,1f,.3f);

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

		if (running || seePlayer)  {
			if (lado == 1) {
				anime.SetInteger("lado", lado);
				transform.Translate (Vector2.up * realVelocity * Time.deltaTime);
			} else if (lado == 2) {
				anime.SetInteger("lado", lado);
				transform.Translate (Vector2.up * -realVelocity * Time.deltaTime);
			} else if (lado == 3) {
				anime.SetInteger("lado", lado);
				transform.eulerAngles = new Vector2(0, 180);
				transform.Translate (Vector2.right * -realVelocity * Time.deltaTime);
			} else if (lado == 4) {
				anime.SetInteger("lado", lado);
				transform.eulerAngles = new Vector2(0, 0);
				transform.Translate (Vector2.right * -realVelocity * Time.deltaTime);
			}
		}			
	}

	void OnCollisionEnter2D (Collision2D colisor) {
		
		if (vunerable && colisor.gameObject.tag == "p_ataque") {

			runDelay = 0.3f;
			lado = 0;
			life -= 1;
			vunerable = false;

		} else if (colisor.gameObject.tag == "Power2") {
			
			life -= 5;
		
		} else if (!seePlayer && 
						(colisor.gameObject.tag == "Background" ||
							colisor.gameObject.tag == "Enimie")) {

			lado -= 1;
			if (lado < 1)
				lado = 4;
		}
	}
}

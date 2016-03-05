using UnityEngine;
using System.Collections;

public class id_player : MonoBehaviour {

	public	Transform player;			// Player atual
	public	Collider2D [] live;			// Verifica se está vivo
	public 	int vidas;					// Quantidade de vidas
	public  GameObject newPlayer;		// Prefab do player
	private GameObject aux; 
	public	Vector3 initialPosition;	// Posição inicial na fase
	public 	Gerenciador gerente;
	
	// Use this for initialization
	void Start () {

		// Cria um player
		this.transform.position = initialPosition;

		aux = (GameObject) Instantiate(newPlayer, transform.position, transform.rotation);
		
		player = aux.transform;
		
	}
	
	// Update is called once per frame
	void Update () {

		// Detecta se existe player vivo
		live = Physics2D.OverlapCircleAll(this.transform.position, 1f, 1 << LayerMask.NameToLayer ("Player"));

		// Se existe segue ele
		if (live.Length > 0) {
			
			Vector3 newPosition = new Vector3 (player.position.x, player.position.y, transform.position.z);
			
			transform.position = new Vector3 (player.position.x, player.position.y, transform.position.z);
			
		} else {  // Se não existe cria um novo

			vidas--;

			if (vidas < 1)
				Application.LoadLevel(0);

			this.transform.position = initialPosition;
			
			aux = (GameObject) Instantiate(newPlayer, transform.position, transform.rotation);
			
			player = aux.transform;
		}
	}

}

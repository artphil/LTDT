using UnityEngine;
using System.Collections;

public class id_player : MonoBehaviour {

	public Transform player;			// Player atual
	public Collider2D [] live;			// Quantidade de vidas
	public  GameObject newPlayer;		// Prefab do player
	private GameObject aux; 
	public	Vector3 initialPosition;	// Posição inicial na fase
	
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
			
			this.transform.position = initialPosition;
			
			aux = (GameObject) Instantiate(newPlayer, transform.position, transform.rotation);
			
			player = aux.transform;
		}
	}

}

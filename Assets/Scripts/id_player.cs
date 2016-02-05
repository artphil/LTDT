using UnityEngine;
using System.Collections;

public class id_player : MonoBehaviour {

	public Transform player;
	public Collider2D [] live;
	public  GameObject newPlayer;
	private GameObject aux; 
	
	// Use this for initialization
	void Start () {
		
		aux = (GameObject) Instantiate(newPlayer, transform.position, transform.rotation);
		
		player = aux.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		live = Physics2D.OverlapCircleAll(this.transform.position, 1f, 1 << LayerMask.NameToLayer ("Player"));
		
		if (live.Length > 0) {
			
			Vector3 newPosition = new Vector3 (player.position.x, player.position.y, transform.position.z);
			
			transform.position = new Vector3 (player.position.x, player.position.y, transform.position.z);
			
		}
		else {
			
			this.transform.position = new Vector3(0,-0.9f,0);
			
			aux = (GameObject) Instantiate(newPlayer, transform.position, transform.rotation);
			
			player = aux.transform;
		}
	}

}

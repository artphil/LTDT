using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	public Transform player;
	public float smooth = 0.5f;
	public float velocity;
	public float posicX;
	public float posicY;
	private Vector2 velocity2D;
	private Vector2 newPosition2D = Vector2.zero;
	private Vector3 newPosition = Vector3.zero; 

	// Use this for initialization
	void Start () 
	{

		velocity2D = new Vector2 (velocity, velocity);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Recupera a posiçao do personagem e amortiza a volocidade da camera
		newPosition2D.x = Mathf.SmoothDamp (transform.position.x, player.position.x, ref velocity2D.x, smooth);
		newPosition2D.y = Mathf.SmoothDamp (transform.position.y, player.position.y, ref velocity2D.y, smooth);

		// Verifica se ha movimento em X que nao ultrapassa a tela
		if (newPosition2D.x > -posicX && newPosition2D.x < posicX)
		{
			newPosition = new Vector3 (newPosition2D.x, newPosition.y, transform.position.z);
		}

		// Verifica se ha movimento em X que nao ultrapassa a tela
		if (newPosition2D.y > -posicY && newPosition2D.y < posicY) 
		{
			newPosition = new Vector3 (newPosition.x, newPosition2D.y, transform.position.z);
		}

		// Atualiza a posiçao da camera
		//newPosition = new Vector3 (newPosition2D.x, newPosition2D.y, transform.position.z);

		transform.position = Vector3.Slerp (transform.position, newPosition, Time.time);

	}
}

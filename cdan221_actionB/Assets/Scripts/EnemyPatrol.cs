using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	private GameHandler gameHandler;
	public int damage = 1;

	public float speed = 2f;
	public Rigidbody2D rb;
	public LayerMask groundLayers;
	public Transform groundCheck;
	bool isFacingRight = true;
	RaycastHit2D hit;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
	}

	void Update(){
		hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
	}

	void FixedUpdate(){
		if (hit.collider != false){
			if (isFacingRight){
				rb.velocity = new Vector2(speed, rb.velocity.y);
			} else { 
				rb.velocity = new Vector2(-speed, rb.velocity.y);
			}
		} else {
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
		}
	}
	
	
	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player"){
			gameHandler.playerGetHit(damage);
		}
	}
	
	
}
